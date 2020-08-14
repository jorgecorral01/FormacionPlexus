using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using MiAPI.Business.Dtos;
using MiAPI.Infrastructure.Repository;
using MiAPI.Infrastructure.SqlRepository;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
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

            var actualvideo = await action.Execute(name);
            
            actualvideo.Should().BeEquivalentTo(expectVideo);
            await videoRepository.Received(1).Find(name);
        }

        [Test]
        public async Task should_return_video_not_found_when_video_not_exist_for_a_name() {
            var name = "peli1";
            var videoRepository = GivenAClsVideoRepositorySqlMock();
            SetVideoNotFoundReturnForVideoRepositoryMock(videoRepository, name );
            var action = new FindVideoAction(videoRepository);

            var actualVideo = await  action.Execute(name);

            actualVideo.Should().BeOfType<VideoNotFound>().Which.name.Should().Be(name);
            await videoRepository.Received(1).Find(name);
        }

        private void SetVideoNotFoundReturnForVideoRepositoryMock(ClsVideoRepositorySql videoRepository, string name){
            videoRepository.Find(name).Throws(new VideoNotFoundException(name));
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

        [Test]
        public void when_we_request_all_the_videos_and_users_we_recover_the_data(){
            var Videos = new List<Video>{new Video{name = "Video1", format = "avi"}};
            var users = new List<User> { new User { Name = "Pedro", Surname = "Pedro1" } };
            var videoRepository = GivenAClsVideoRepositorySqlMock();
            var userRepository = Substitute.For<ClsUserRepositorySql>();
            videoRepository.GetAll().Returns(Videos);
            userRepository.GetAll().Returns(users);
            var videoAction = new GetAllVideosAndUserAction(videoRepository, userRepository);

            var actualDataList = videoAction.Execute();

            actualDataList.Videos.Should().HaveCount(1);
            actualDataList.Users.Should().HaveCount(1);
            videoRepository.Received(1).GetAll();
            userRepository.Received(1).GetAll();
        }

        private static AddVideoAction GivenAnAddAction(ClsVideoRepositorySql clsVideoRepositorySql){
            return new AddVideoAction(clsVideoRepositorySql);
        }

        private static ClsVideoRepositorySql GivenAClsVideoRepositorySqlMock(){
            return Substitute.For<ClsVideoRepositorySql>(new object[] { null });
        }
    }
}
