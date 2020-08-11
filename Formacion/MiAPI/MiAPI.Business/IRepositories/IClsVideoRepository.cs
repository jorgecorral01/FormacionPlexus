using System.Threading.Tasks;
using MiAPI.Business.Dtos;

namespace MiAPI.Business.IRepositories{
    public interface IClsVideoRepository{
        void Add(Video newVideo);
        Video Find(string name);
    }
}