using System.Threading.Tasks;
using MiAPI.Business.Dtos;

namespace MiAPI.Repositories.interfaces{
    public interface IClsVideoRepository{
        void Add(Video newVideo);
        Task<Video> Find(string name);
    }
}