using MiAPI.Actions;
using MiAPI.Repositories;
using MiAPI.Repositories.interfaces;

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
