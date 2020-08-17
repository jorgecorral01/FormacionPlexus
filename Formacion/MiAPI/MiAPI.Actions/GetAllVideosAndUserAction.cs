using System;
using System.Threading.Tasks;
using MiAPI.Business.Dtos;
using MiAPI.Business.IRepositories;
using MiAPI.Infrastructure.Repository;
using MiAPI.Infrastructure.SqlRepository;

namespace MiAPI.Actions {
    public class GetAllVideosAndUserAction {
        private readonly IClsVideoRepository _videoRepository;
        private readonly ClsUserRepositorySql _userRepository;

        public GetAllVideosAndUserAction(IClsVideoRepository videoRepository, ClsUserRepositorySql userRepository) {
            _videoRepository = videoRepository;
            _userRepository = userRepository;
        }

        public async Task<DataList> Execute() {
            try {


                await Task.Delay(1);
                var dataList = new DataList {
                    Videos = _videoRepository.GetAll(),
                    Users = _userRepository.GetAll()
                };
                return dataList;
            }
            catch(Exception e) {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}