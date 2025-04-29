using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AutoMapper;
using Hangfire;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Services
{
    public class PanMusicService : IPanMusicService
    {
        private readonly IPanMusicRepo _repo;
        private readonly IFileRepo _fileRepo;
        private UserIdentifier _user;
        private IBackgroundJobClient _backgroundJobClient;
        private readonly FileConfig _fileConfig;

        public PanMusicService(IPanMusicRepo PanMusicRepo, IFileRepo fileRepo, IBackgroundJobClient backgroundJobClient, FileConfig fileConfig)
        {
            _repo = PanMusicRepo;
            _fileRepo = fileRepo;
            _backgroundJobClient = backgroundJobClient;
            _fileConfig = fileConfig;
        }

        public void SetUser(UserIdentifier user)
        {
            _user = user;
        }

        public CreatePanMusicResponse CreatePanMusic(CreatePanMusicRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }


            PanMusic PanMusic = null;
            try
            {
                PanMusic = new PanMusic
                {
                    userId = _user.UserId,
                    title = request.title,
                    durationInSecs = request.durationInSecs,
                    fileName = _fileRepo.UploadFile(request.music, FileType.PanMusic),
                };
                _repo.Insert(PanMusic);
                
                // TODO: convert music to aac
            }
            catch (Exception)
            {
                if (PanMusic?.fileName != null)
                {
                    _fileRepo.RemoveFile(FileType.PanMusic, PanMusic.fileName);
                }
                throw;
            }


            return new CreatePanMusicResponse
            {
                id = PanMusic.id,
            };
        }


        public void DeletePanMusic(int id)
        {
            var PanMusic = _repo.GetById(id);
            _repo.Delete(id);
            _fileRepo.RemoveFile(FileType.PanMusic, PanMusic.fileName);
        }

        public List<PanMusicResposne> GetMyPanMusics(PanMusicFilter filter, out Meta meta)
        {
            var PanMusics = Fill(filter, out meta)
                .Where(PanMusic => PanMusic.userId == _user.UserId)
                .ToList();
            return Mapper.Map<List<PanMusicResposne>>(PanMusics);
        }


        public List<PanMusicResposne> GetPanMusics(PanMusicFilter filter, out Meta meta)
        {
            // TODO: order panmusics by popularity  
            var PanMusics = Fill(filter, out meta)
                .ToList();
            return Mapper.Map<List<PanMusicResposne>>(PanMusics);
        }


        public List<PanMusic> Fill(PanMusicFilter filter, out Meta meta)
        {
            var filledEntities = Fill(filter);

            meta = Meta.ProcessAndCreate(filledEntities.Count(), filter);

            return MyUtil.Page(filledEntities, filter);
        }

        public virtual IQueryable<PanMusic> Fill(PanMusicFilter filter)
        {
            return _repo.GetIQueryable()
                .Where((entity) => !entity.isDeleted);
        }
    }
}