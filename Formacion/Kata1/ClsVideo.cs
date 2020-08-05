using System.Collections.Generic;
using System.Runtime.InteropServices;
using Kata1.Dtos;

namespace Kata1{
    public class ClsVideo{
        private List<Video> listVideos;
        public ClsVideo(){
            listVideos = new List<Video>();
        }
        public Video Add(Video newVideo){
            return newVideo;
        }
    }
}