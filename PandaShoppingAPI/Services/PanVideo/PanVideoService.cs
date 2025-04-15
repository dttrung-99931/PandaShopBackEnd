using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

        public PanVideoService(IPanVideoRepo panVideoRepo, IFileRepo fileRepo)
        {
            _repo = panVideoRepo;
            _fileRepo = fileRepo;
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
    }
}