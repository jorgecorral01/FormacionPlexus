using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MiAPI.Business.Dtos;
using MiAPI.Business.IRepositories;

namespace MiAPI.Repositories{
    public class ClsVideoRepository : IClsVideoRepository {
        public List<Video> LisTVideos { get; set; }

        public ClsVideoRepository(){
            LisTVideos = new List<Video>();
        }
        public void Add(Video newVideo){
            LisTVideos.Add(newVideo);
        }

        public virtual Video Find(string name){
            
            return LisTVideos.FirstOrDefault(item => item.name == name);
        }

    }
}
