using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MiAPI.Business.Dtos;

using MiAPI.Repositories.interfaces;

namespace MiAPI.Repositories{
    public class ClsVideoRepository : IClsVideoRepository {
        public List<Video> LisTVideos { get; set; }

        public ClsVideoRepository(){
            LisTVideos = new List<Video>();
        }
        public void Add(Video newVideo){
            LisTVideos.Add(newVideo);
        }

        public virtual async Task<Video> Find(string name){
            await Task.Delay(1);
            
            return new Video{name = name, format = "avi"};
        }

    }
}
