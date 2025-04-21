using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Http;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Services 
{
    public class PanVideoService : IPanVideoService
    {
        private readonly IPanVideoRepo _repo;
        private readonly IFileRepo _fileRepo;
        private UserIdentifier _user;
        private IBackgroundJobClient _backgroundJobClient;
        private readonly FileConfig _fileConfig;
        private readonly PanvideoEncoderFactory _videoEncoderFactory;

        public PanVideoService(IPanVideoRepo panVideoRepo, IFileRepo fileRepo, IBackgroundJobClient backgroundJobClient, FileConfig fileConfig, PanvideoEncoderFactory videoEncoderFactory, ThumbnailVideoService thumbnailVideoService)
        {
            _repo = panVideoRepo;
            _fileRepo = fileRepo;
            _backgroundJobClient = backgroundJobClient;
            _fileConfig = fileConfig;
            _videoEncoderFactory = videoEncoderFactory;
        }

        public void SetUser(UserIdentifier user)
        {
            _user = user;
        }

        public CreatePanVideoResponse CreatePanVideo(CreatePanVideoRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            
            PanVideo panVideo = null;
            try
            {
                panVideo = new PanVideo
                {
                    userId = _user.UserId,
                    title = request.title,
                    description = request.description,
                    durationInSecs = request.durationInSecs,
                    thumbImageFileName = _fileRepo.UploadFile(request.thumbnailImage, FileType.PanVideoThumbImage),
                    fileName = _fileRepo.UploadFile(request.video, FileType.PanVideo),
                };
                _repo.Insert(panVideo);

                // Enqueue job to convert panvideo to streaming video file for faster loading
                ConvertPanvideoStreamingInBackground(panVideo.id);
            }
            catch (Exception)
            {
                if (panVideo?.thumbImageFileName != null)
                {
                    _fileRepo.RemoveFile(FileType.PanVideoThumbImage, panVideo.thumbImageFileName);
                }
                if (panVideo?.fileName != null)
                {
                    _fileRepo.RemoveFile(FileType.PanVideo, panVideo.fileName);
                }
                throw;
            }

            
            return new CreatePanVideoResponse
            {
                id = panVideo.id,
            };               
        }


        public void DeletePanVideo(int id)
        {
            var panVideo = _repo.GetById(id);
            _repo.Delete(id);
            _fileRepo.RemoveFile(FileType.PanVideoThumbImage, panVideo.thumbImageFileName);
            _fileRepo.RemoveFile(FileType.PanVideo, panVideo.fileName);
        }

        public List<PanVideoResposne> GetMyPanvideos(PanvideoFilter filter, out Meta meta)
        {
            var panvideos = Fill(filter, out meta)
                .Where(panvideo => panvideo.userId == _user.UserId)
                .ToList();
            return Mapper.Map<List<PanVideoResposne>>(panvideos);
        }


        public List<PanVideoResposne> GetPanvideos(PanvideoFilter filter, out Meta meta)
        {
            // TODO: get related panvidoes 
            var panvideos = Fill(filter, out meta)
                .ToList();
            return Mapper.Map<List<PanVideoResposne>>(panvideos);
        }


        public List<PanVideo> Fill(PanvideoFilter filter, out Meta meta)
        {
            var filledEntities = Fill(filter);
            
            meta = Meta.ProcessAndCreate(filledEntities.Count(), filter);

            return MyUtil.Page(filledEntities, filter);
        }

        public virtual IQueryable<PanVideo> Fill(PanvideoFilter filter)
        {
            return _repo.GetIQueryable()
                .Where((entity) => !entity.isDeleted);
        }


        public void ConvertPanvideoStreaming(int panvideoId)
        {
            PanVideo panvideo = _repo.GetById(panvideoId);
            string outputDirPath = _fileConfig.GetPanVideoDirPath();
            string originVideoPath = $"{outputDirPath}/{panvideo.fileName}";
            if (!File.Exists(originVideoPath)){
                Console.WriteLine($"Not found video to convert streaming at path = {originVideoPath}, panvideo id = {panvideoId}");
                return;
            }
            
            string fileNameWithoutExt = panvideo.fileName.Split('.').First();
            // DASH video converting
            bool successDASH = _videoEncoderFactory.GetEncoder(PanvieoEncoders.dash)
                .Encode(originVideoPath, outputDirPath, fileNameWithoutExt);
            // HLS video converting
            bool successHLS = _videoEncoderFactory.GetEncoder(PanvieoEncoders.hls)
                .Encode(originVideoPath, outputDirPath, fileNameWithoutExt);
            if ((successDASH || successHLS) && !panvideo.supportStreaming)
            {
                panvideo.fileName = fileNameWithoutExt;
                panvideo.supportStreaming = true;
                _repo.Update(panvideo, panvideo.id);
            }
            if (!Debugger.IsAttached && successDASH && successHLS)
            {
                File.Delete(originVideoPath);
            }
        }

        public void ConvertPanvideoStreamingInBackground(int panvideoId)
        {
            _backgroundJobClient.Enqueue<IPanVideoService>
            (
                (service) => service.ConvertPanvideoStreaming(panvideoId)
            );
        }

        public void ConvertAllPanvideosToStreamingInBackground()
        {
            _backgroundJobClient.Enqueue<PanVideoService>
            (
                (service) => service.ConvertAllPanvideosToStreaming()
            );
        }

        public void ConvertAllPanvideosToStreaming()
        {
            List<int> unsupportSteamingIds = _repo.Where((panvideo) => !panvideo.supportStreaming)
                .Select((panvideo) => panvideo.id)
                .ToList();
            unsupportSteamingIds.ForEach
            (
                (id) => ConvertPanvideoStreaming(id)
            );
        }
    }
}