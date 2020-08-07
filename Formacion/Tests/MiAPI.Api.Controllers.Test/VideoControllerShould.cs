using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using MiAPI.Business.Dtos;
using MiAPI.Repositories;
using MiAPI.Repositories.interfaces;
using NSubstitute;
using NUnit.Framework;

namespace MiAPI.Api.Controllers.Test{
    public class VideoControllerShould{
        [Test]
        public async Task when_we_ask_for_a_video_we_obtain(){
            var nombreVideoABuscar = "fiesta";
            var expectedVideo = new Video { format = "avi", name = nombreVideoABuscar };
            HttpClient client = new HttpClient();
            var requestUri = string.Format("http://localhost:35555/api/video/{0}", nombreVideoABuscar);
            var clsVideoRepository = Substitute.For<ClsVideoRepository>();
            clsVideoRepository.Find(nombreVideoABuscar).Returns(expectedVideo);

            var result = await client.GetAsync(requestUri);
            var actualVideo = Newtonsoft.Json.JsonConvert.DeserializeObject<Video>(result.Content.ReadAsStringAsync().Result);
            
            actualVideo.Should().BeEquivalentTo(expectedVideo);
            // TODO  await clsVideoRepository.Received(1).Find(nombreVideoABuscar);
        }
    }
}
