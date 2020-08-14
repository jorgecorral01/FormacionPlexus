using System.Collections.Generic;
using MiAPI.Business.Dtos;

namespace MiAPI.Business.IRepositories{
    public interface IClsUserRepository{
        List<User> GetAll();
    }
}
