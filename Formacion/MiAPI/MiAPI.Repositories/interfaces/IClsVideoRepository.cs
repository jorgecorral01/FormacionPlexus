using System.Threading.Tasks;
using MiAPI.Business.Dtos;

namespace MiAPI.Repositories.interfaces{
    public interface IClsVideoRepository{
        Video Add(Video newVideo);
        Task<Video> Find(string name);
    }
}