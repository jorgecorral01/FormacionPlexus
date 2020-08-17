using MiAPI.Actions;
using MiAPI.Business.IRepositories;
using MiAPI.Infrastructure.Repository;
using MiAPI.Infrastructure.Repository.Models;
using MiAPI.Infrastructure.SqlRepository;

namespace MiAPI.API.Factories{
    public class ClsActionFactory{
        private readonly string _connectionString;

        public ClsActionFactory(string connectionString) {
            this._connectionString = connectionString;
        }

        public FindVideoAction CreateFindVideoAction(){
            return  new FindVideoAction(new ClsVideoRepositoryEntitySql(new VideoClubContext()));
        }

        public AddVideoAction CreateAddVideoAction(){
            return new AddVideoAction(new ClsVideoRepositorySql(_connectionString));
        }

        public GetAllVideosAndUserAction CreateGetAllVideosAndUserAction(){
            return new GetAllVideosAndUserAction(new ClsVideoRepositorySql(_connectionString), new ClsUserRepositorySql());
        }
    }
}
