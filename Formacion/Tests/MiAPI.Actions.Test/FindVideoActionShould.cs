using System;
using System.Threading.Tasks;
using FluentAssertions;
using MiAPI.Business.Dtos;
using MiAPI.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace MiAPI.Actions.Test {
    public class FindVideoActionShould {
        [Test]
        public async Task   should_return_a_video_for_a_name(){
            var videoRepository = new ClsVideoRepository();
            var action = new FindVideoAction(videoRepository);
            var nombre = "peli1";

            var actualvideo = await action.Execute(nombre);

            var expectVideo = new Video{name = nombre,format = "avi"};
            actualvideo.Should().BeEquivalentTo(expectVideo);
        }
    }
}
