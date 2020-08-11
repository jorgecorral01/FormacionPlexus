using System;

namespace MiAPI.Business.Dtos{
    public class Video{
        public string name{ get; set; }
        public string format{ get; set; }
    }

    public class VideoNotFoundException : Exception{
        public readonly string Name;
        
        public VideoNotFoundException(string name){
            Name = name;
        }
    }
}