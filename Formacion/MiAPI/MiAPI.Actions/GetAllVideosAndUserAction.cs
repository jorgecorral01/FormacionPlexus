using System;
using System.Threading.Tasks;
using MiAPI.Business.Dtos;
using MiAPI.Infrastructure.Repository;
using MiAPI.Infrastructure.SqlRepository;

namespace MiAPI.Actions {
    public class GetAllVideosAndUserAction {
        private readonly ClsVideoRepositorySql _videoRepository;
        private readonly ClsUserRepositorySql _userRepository;

        public GetAllVideosAndUserAction(ClsVideoRepositorySql videoRepository, ClsUserRepositorySql userRepository) {
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