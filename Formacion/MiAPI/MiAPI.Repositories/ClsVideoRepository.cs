using System.Threading.Tasks;
using MiAPI.Business.Dtos;
using MiAPI.Repositories.interfaces;

namespace MiAPI.Repositories{
    public class ClsVideoRepository : IClsVideoRepository {
        public Video Add(Video newVideo){
            throw new System.NotImplementedException();
        }

        public async Task<Video> Find(string name){
            await Task.Delay(1);
            return new Video{name = name, format = "avi"};
        }
    }
}
