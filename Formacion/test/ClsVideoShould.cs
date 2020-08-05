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
            var newVideo = new Video { name = "fakeVideo", format = "avi" };
            var clsVideoRepositoty = GivenAClsVideoRepositoty(newVideo);
            var clsVideo = new ClsVideo(clsVideoRepositoty);

            var actualVideo =  clsVideo.Add(newVideo);

            actualVideo.Should().BeEquivalentTo(newVideo);
            clsVideoRepositoty.Received(1).Add(newVideo);
        }

        private static IClsVideoRepositoty GivenAClsVideoRepositoty(Video newVideo){
            IClsVideoRepositoty clsVideoRepositoty = Substitute.For<IClsVideoRepositoty>();
            clsVideoRepositoty.Add(newVideo).Returns(newVideo);
            return clsVideoRepositoty;
        }
    }
}
