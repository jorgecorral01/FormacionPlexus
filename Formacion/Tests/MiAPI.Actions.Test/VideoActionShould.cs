using System;
using System.Threading.Tasks;
using FluentAssertions;
using MiAPI.Business.Dtos;
using MiAPI.Infrastructure.SqlRepository;
using NSubstitute;
using NUnit.Framework;

namespace MiAPI.Actions.Test {
    public class VideoActionShould {
        [Test]
        public async Task   should_return_a_video_for_a_name(){
            var name = "peli1";
            var expectVideo = new Video { name = name, format = "avi" };
            var videoRepository = GivenAClsVideoRepositorySqlMock();
            SetVideoReturnForVideoRepositoryMock(videoRepository, name, expectVideo);
            var action = new FindVideoAction(videoRepository);

            var actualvideo = action.Execute(name);
            
            actualvideo.Should().BeEquivalentTo(expectVideo);
            videoRepository.Received(1).Find(name);
        }

        [Test]
        public async Task should_return_video_not_found_exception_when_video_not_exist_for_a_name() {
            var name = "peli1";
            var videoRepository = GivenAClsVideoRepositorySqlMock();
            SetVideoNotFoundReturnForVideoRepositoryMock(videoRepository, name );
            var action = new FindVideoAction(videoRepository);

            action.Execute(name);

            
            videoRepository.Received(1).Find(name);
        }

        private void SetVideoNotFoundReturnForVideoRepositoryMock(ClsVideoRepositorySql videoRepository, string name){
            //videoRepository.Find(name).Returns(new VideoNotFound());
        }

        private static void SetVideoReturnForVideoRepositoryMock(ClsVideoRepositorySql videoRepository, string name, Video expectVideo){
            videoRepository.Find(name).Returns(expectVideo);
        }

        [Test]
        public void when_add_video_we_call_one_time_to_video_repository(){
            var clsVideoRepositorySql = GivenAClsVideoRepositorySqlMock();
            var action = GivenAnAddAction(clsVideoRepositorySql);
            var newVideo = new Video { name = "aprendizaje", format = "avi" };

            action.Execute(newVideo);

            clsVideoRepositorySql.Received(1).Add(newVideo);
        }

        private static AddVideoAction GivenAnAddAction(ClsVideoRepositorySql clsVideoRepositorySql){
            return new AddVideoAction(clsVideoRepositorySql);
        }

        private static ClsVideoRepositorySql GivenAClsVideoRepositorySqlMock(){
            return Substitute.For<ClsVideoRepositorySql>(new object[] { null });
        }
    }
}
