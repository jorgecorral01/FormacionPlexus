using System;
using System.Threading.Tasks;
using MiAPI.Business.Dtos;
using MiAPI.Business.IRepositories;

namespace MiAPI.Actions {
    public class FindVideoAction {
        private readonly IClsVideoRepository _clsVideoRepository;

        public FindVideoAction(IClsVideoRepository clsVideoRepository){
            _clsVideoRepository = clsVideoRepository;
        }

        public async Task<Video> Execute(string name){
            try{
                return await _clsVideoRepository.Find(name);
            }
            catch (VideoNotFoundException e){
                return new VideoNotFound(e.Name);
            }
            
        }
    }
}
