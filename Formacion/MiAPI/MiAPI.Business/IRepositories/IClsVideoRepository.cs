using System.Collections.Generic;
using System.Threading.Tasks;
using MiAPI.Business.Dtos;

namespace MiAPI.Business.IRepositories{
    public interface IClsVideoRepository{
        void Add(Video newVideo);
        Task<Video> Find(string name);
        List<Video> GetAll();
    }
}