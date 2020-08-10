using MiAPI.Actions;
using MiAPI.Business.IRepositories;
using MiAPI.Repositories;

namespace MiAPI.API.Factories{
    public class ClsVideoRepositoryFactory{
        private readonly IClsVideoRepository _clsVideoRepository;

        

        public FindVideoAction CreateFindVideoAction(){
            var clsVideoRepository = new ClsVideoRepository();
            return  new FindVideoAction(clsVideoRepository);
            //return _clsVideoRepository.Find();
        }
    }
}
