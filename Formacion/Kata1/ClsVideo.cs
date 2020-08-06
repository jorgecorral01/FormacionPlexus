using System.Collections.Generic;
using System.Runtime.InteropServices;
using Kata1.Dtos;
using Kata1.Interfaces;
using MiAPI.Business.Dtos;

namespace Kata1{
    public class ClsVideo{
        private readonly IClsVideoRepositoty _clsVideoRepositoty;
        private List<Video> listVideos;
        public ClsVideo(IClsVideoRepositoty clsVideoRepositoty){
            _clsVideoRepositoty = clsVideoRepositoty;
            listVideos = new List<Video>();
        }
        public Video Add(Video newVideo){
            return _clsVideoRepositoty.Add(newVideo);
        }
    }
}