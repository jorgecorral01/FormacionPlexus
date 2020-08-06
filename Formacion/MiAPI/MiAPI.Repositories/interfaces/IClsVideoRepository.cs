using MiAPI.Business.Dtos;

namespace MiAPI.Repositories.interfaces{
    public interface IClsVideoRepository{
        Video Add(Video newVideo);
        Video Find(string name);
    }
}