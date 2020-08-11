using MiAPI.Actions;
using MiAPI.Business.IRepositories;
using MiAPI.Infrastructure.SqlRepository;

namespace MiAPI.API.Factories{
    public class ClsVideoRepositoryFactory{
        private readonly string _connectionString;

        public ClsVideoRepositoryFactory(string connectionString) {
            this._connectionString = connectionString;
        }

        public FindVideoAction CreateFindVideoAction(){
            return  new FindVideoAction(new ClsVideoRepositorySql(_connectionString));
            //return new FindVideoAction(_clsVideoRepository);
            //return _clsVideoRepository.Find();
        }

        public AddVideoAction CreateAddVideoAction(){
            return new AddVideoAction(new ClsVideoRepositorySql(_connectionString));
        }
    }
}
