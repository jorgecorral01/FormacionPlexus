using FluentAssertions;
using Kata1;
using Kata1.Dtos;
using MiAPI.Business.Dtos;
using NSubstitute;
using NUnit.Framework;
namespace test{
    public class ClsVideoShould{
        //[Test]
        //public void when_create_new_video_return_the_same_video(){
        //    var newVideo = new Video { name = "fakeVideo", format = "avi" };
        //    var clsVideoRepositoty = GivenAClsVideoRepositoty(newVideo);
        //    var clsVideo = new ClsVideo(clsVideoRepositoty);

        //    var actualVideo =  clsVideo.Add(newVideo);

        //    actualVideo.Should().BeEquivalentTo(newVideo);
        //    clsVideoRepositoty.Received(1).Add(newVideo);
        //}

        //private static IClsVideoRepository GivenAClsVideoRepositoty(Video newVideo){
        //    IClsVideoRepository clsVideoRepository = Substitute.For<IClsVideoRepository>();
        //    clsVideoRepository.Add(newVideo).Returns(newVideo);
        //    return clsVideoRepository;
        //}
    }
}
