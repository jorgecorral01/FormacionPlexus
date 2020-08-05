using FluentAssertions;
using Kata1;
using Kata1.Dtos;
using NSubstitute;
using NUnit.Framework;
namespace test{
    public class ClsVideoShould{
        [Test]
        public void when_create_new_video_return_the_same_video(){
            var newVideo = new Video{name = "fakeVideo", format="avi"};
            var clsVideo = new ClsVideo();

            var actualVideo =  clsVideo.Add(newVideo);

            actualVideo.Should().BeEquivalentTo(newVideo);

        }
    }
}
