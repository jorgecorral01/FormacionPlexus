using System;
using System.Threading.Tasks;
using MiAPI.Business.Dtos;
using MiAPI.Business.IRepositories;
using MiAPI.Repositories;

namespace MiAPI.Actions {
    public class FindVideoAction {
        private readonly IClsVideoRepository _clsVideoRepository;

        public FindVideoAction(IClsVideoRepository clsVideoRepository){
            _clsVideoRepository = clsVideoRepository;
        }

        public async Task<Video> Execute(string name){
            return await _clsVideoRepository.Find(name);
        }
    }
}
