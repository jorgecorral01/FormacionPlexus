using MiAPI.Business.Dtos;
using MiAPI.Infrastructure.SqlRepository;

namespace MiAPI.Actions{
    public class AddVideoAction{
        private readonly ClsVideoRepositorySql _clsVideoRepositorySql;

        public AddVideoAction(ClsVideoRepositorySql clsVideoRepositorySql){
            _clsVideoRepositorySql = clsVideoRepositorySql;
        }

        public async void Execute(Video newVideo){
            _clsVideoRepositorySql.Add(newVideo);
        }
    }
}