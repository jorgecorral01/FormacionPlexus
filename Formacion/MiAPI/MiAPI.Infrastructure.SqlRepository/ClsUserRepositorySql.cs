using System.Collections.Generic;
using MiAPI.Business.Dtos;
using MiAPI.Business.IRepositories;

namespace MiAPI.Infrastructure.Repository{
    public class ClsUserRepositorySql: IClsUserRepository {
        public virtual List<User> GetAll(){
            return new List<User>();
        }
    }
}