using System;
using System.Threading.Tasks;
using FluentAssertions;
using MiAPI.Business.Dtos;
using MiAPI.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace MiAPI.Actions.Test {
    public class VideoActionShould {
        [Test]
        public async Task   should_return_a_video_for_a_name(){
            var videoRepository = new ClsVideoRepository();
            var action = new FindVideoAction(videoRepository);
            var nombre = "peli1";
            var expectVideo = new Video { name = nombre, format = "avi" };
            videoRepository.Add(expectVideo);

            var actualvideo = await action.Execute(nombre);
            
            actualvideo.Should().BeEquivalentTo(expectVideo);
        }

        [Test]
        public void when_add_video_we_have_one_more_video() {
            var videoRepository = new ClsVideoRepository();
            var action = new AddVideoAction(videoRepository);
            var newVideo = new Video { name = "aprendizaje", format = "avi" };

            action.Execute(newVideo);

            videoRepository.LisTVideos.Should().HaveCount(1);
        }

    }
}
