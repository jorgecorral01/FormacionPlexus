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

        [Test]
        public void when_add_video_we_call_one_time_to_video_repository() {
            var clsVideoRepositorySql = GivenAClsVideoRepositorySqlMock();
            var action = GivenAnAddAction(clsVideoRepositorySql);
            var newVideo = new Video { name = "aprendizaje", format = "avi" };

            action.Execute(newVideo);

            clsVideoRepositorySql.Received(1).Add(newVideo);
        }

        [Test]
        public async Task when_we_request_all_the_videos_and_users_we_recover_the_data() {
            var expectedVideo = new Video { name = "Video1", format = "avi" };
            var Videos = new List<Video> { expectedVideo };
            var expectedUser = new User { Name = "Pedro", Surname = "Pedro1" };
            var users = new List<User> { expectedUser };
            var videoRepository = GivenVideoRepositoryWithDataReturn(Videos);
            var userRepository = GivenUserRepositoryWithDataReturn(users);
            var videoAction = new GetAllVideosAndUserAction(videoRepository, userRepository);

            var actualDataList = await videoAction.Execute();

            ValidateResult(actualDataList, expectedVideo, expectedUser, videoRepository, userRepository);
        }

        private void SetVideoNotFoundReturnForVideoRepositoryMock(ClsVideoRepositorySql videoRepository, string name){
            videoRepository.Find(name).Throws(new VideoNotFoundException(name));
        }

        private static void SetVideoReturnForVideoRepositoryMock(ClsVideoRepositorySql videoRepository, string name, Video expectVideo){
            videoRepository.Find(name).Returns(expectVideo);
        }

       

        private static void ValidateResult(DataList actualDataList, Video expectedVideo, User expectedUser, ClsVideoRepositorySql videoRepository,
            ClsUserRepositorySql userRepository){
            actualDataList.Videos.Should().HaveCount(1);
            actualDataList.Videos[0].Should().BeEquivalentTo(expectedVideo);
            actualDataList.Users.Should().HaveCount(1);
            actualDataList.Users[0].Should().BeEquivalentTo(expectedUser);
            videoRepository.Received(1).GetAll();
            userRepository.Received(1).GetAll();
        }

        private static ClsUserRepositorySql GivenUserRepositoryWithDataReturn(List<User> users){
            var userRepository = GivenAClsUserRepositorySqlMock();
            GivenDataReturnForUserRepositoryMockGetAll(userRepository, users);
            return userRepository;
        }

        private static ClsVideoRepositorySql GivenVideoRepositoryWithDataReturn(List<Video> Videos){
            var videoRepository = GivenAClsVideoRepositorySqlMock();
            GivenDataReturnForVideoRepositoryMockGetAll(videoRepository, Videos);
            return videoRepository;
        }

        private static void GivenDataReturnForUserRepositoryMockGetAll(ClsUserRepositorySql userRepository, List<User> users){
            userRepository.GetAll().Returns(users);
        }

        private static ClsUserRepositorySql GivenAClsUserRepositorySqlMock(){
            return Substitute.For<ClsUserRepositorySql>();
        }

        private static void GivenDataReturnForVideoRepositoryMockGetAll(ClsVideoRepositorySql videoRepository, List<Video> Videos){
            videoRepository.GetAll().Returns(Videos);
        }

        private static AddVideoAction GivenAnAddAction(ClsVideoRepositorySql clsVideoRepositorySql){
            return new AddVideoAction(clsVideoRepositorySql);
        }

        private static ClsVideoRepositorySql GivenAClsVideoRepositorySqlMock(){
            return Substitute.For<ClsVideoRepositorySql>(new object[] { null });
        }
    }
}
