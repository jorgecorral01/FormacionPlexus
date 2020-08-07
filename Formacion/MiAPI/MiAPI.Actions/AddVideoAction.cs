using MiAPI.Business.Dtos;
using MiAPI.Repositories;

namespace MiAPI.Actions{
    public class AddVideoAction{
        private readonly ClsVideoRepository _videoRepository;

        public AddVideoAction(ClsVideoRepository videoRepository){
            _videoRepository = videoRepository;
        }

        public async void Execute(Video newVideo){
            _videoRepository.Add(newVideo);
        }
    }
}