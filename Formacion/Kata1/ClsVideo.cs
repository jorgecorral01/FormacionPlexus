using System.Collections.Generic;
using System.Runtime.InteropServices;
using Kata1.Dtos;
using MiAPI.Business.Dtos;
using MiAPI.Repositories.interfaces;

namespace Kata1{
    public class ClsVideo{
        private readonly IClsVideoRepository _clsVideoRepository;
        private List<Video> listVideos;
        public ClsVideo(IClsVideoRepository clsVideoRepository){
            _clsVideoRepository = clsVideoRepository;
            listVideos = new List<Video>();
        }
        public Video Add(Video newVideo){
            return _clsVideoRepository.Add(newVideo);
        }
    }
}