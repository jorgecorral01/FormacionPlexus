using System;
using System.Threading.Tasks;
using MiAPI.Business.Dtos;
using MiAPI.Repositories;

namespace MiAPI.Actions {
    public class FindVideoAction {
        private readonly ClsVideoRepository _clsVideoRepository;

        public FindVideoAction(ClsVideoRepository clsVideoRepository){
            _clsVideoRepository = clsVideoRepository;
        }

        public async Task<Video> Execute(string name){
            return await _clsVideoRepository.Find(name);
        }
    }
}
