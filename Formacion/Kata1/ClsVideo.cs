using System.Collections.Generic;
using System.Runtime.InteropServices;
using Kata1.Dtos;
using Kata1.Interfaces;

namespace Kata1{
    public class ClsVideo{
        private readonly IClsRepositotyVideo _clsRepositotyVideo;
        private List<Video> listVideos;
        public ClsVideo(IClsRepositotyVideo clsRepositotyVideo){
            _clsRepositotyVideo = clsRepositotyVideo;
            listVideos = new List<Video>();
        }
        public Video Add(Video newVideo){
            return _clsRepositotyVideo.Add(newVideo);
        }
    }
}