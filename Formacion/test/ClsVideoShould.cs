using FluentAssertions;
using Kata1;
using Kata1.Dtos;
using Kata1.Interfaces;
using NSubstitute;
using NUnit.Framework;
namespace test{
    public class ClsVideoShould{
        [Test]
        public void when_create_new_video_return_the_same_video(){
            IClsRepositotyVideo clsRepositotyVideo = Substitute.For<IClsRepositotyVideo>();
            var newVideo = new Video{name = "fakeVideo", format="avi"};
            var clsVideo = new ClsVideo(clsRepositotyVideo);
            clsRepositotyVideo.Add(newVideo).Returns(newVideo);
            
            var actualVideo =  clsVideo.Add(newVideo);

            actualVideo.Should().BeEquivalentTo(newVideo);
            clsRepositotyVideo.Received(1).Add(newVideo);
        }
    }
}
