using System;
using Microsoft.AspNetCore.Http;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services 
{
    public class PanVideoService : IPanVideoService
    {
        private readonly IPanVideoRepo _panVideoRepo;
        private readonly IFileRepo _fileRepo;
        private UserIdentifier _user;

        public PanVideoService(IPanVideoRepo panVideoRepo, IFileRepo fileRepo)
        {
            _panVideoRepo = panVideoRepo;
            _fileRepo = fileRepo;
        }
        
        public void SetUser(UserIdentifier user)
        {
            _user = user;
        }

        public PanVideoResponse CreatePanVideo(PanVideoRequest request)
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
                _panVideoRepo.Insert(panVideo);
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

            
            return new PanVideoResponse
            {
                id = panVideo.id,
            };               
        }

        public void DeletePanVideo(int id)
        {
            var panVideo = _panVideoRepo.GetById(id);
            _panVideoRepo.Delete(id);
            _fileRepo.RemoveFile(FileType.PanVideoThumbImage, panVideo.thumbImageFileName);
            _fileRepo.RemoveFile(FileType.PanVideo, panVideo.fileName);
        }
    }
}