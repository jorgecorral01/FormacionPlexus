using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiAPI.Business.Dtos;
using MiAPI.Business.IRepositories;
using MiAPI.Infrastructure.Repository.Models;
using Remotion.Linq.Utilities;

namespace MiAPI.Infrastructure.SqlRepository{
    public class ClsVideoRepositoryEntitySql :IClsVideoRepository{
        private readonly VideoClubContext _videoClubContext;

        public ClsVideoRepositoryEntitySql(VideoClubContext videoClubContext){
            _videoClubContext = videoClubContext;
            
        }

        public void Add(Video newVideo){
            throw new System.NotImplementedException();
        }

        public async Task<Video> Find(string name){
            var video = _videoClubContext.Videos
                .Where(item => item.Name == name)
                .Select(item =>   new Video{name = item.Name, format = item.Format})
                .FirstOrDefault();
            await Task.Delay(1);
            return  video;
        }

        public List<Video> GetAll(){
            throw new System.NotImplementedException();
        }
    }
}
