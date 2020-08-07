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
            var expectedVideo = ForGivenData(out var client, out var requestUri);

            var actualVideo = await FindVideo(client, requestUri);

            actualVideo.Should().BeEquivalentTo(expectedVideo);
        }

        private static Video ForGivenData(out HttpClient client, out string requestUri){
            var nombreVideoABuscar = "fiesta";
            var expectedVideo = new Video{format = "avi", name = nombreVideoABuscar};
            client = new HttpClient();
            requestUri = string.Format("http://localhost:35555/api/video/{0}", nombreVideoABuscar);
            return expectedVideo;
        }

        private static async Task<Video> FindVideo(HttpClient client, string requestUri){
            var result = await client.GetAsync(requestUri);
            var actualVideo = Newtonsoft.Json.JsonConvert.DeserializeObject<Video>(result.Content.ReadAsStringAsync().Result);
            return actualVideo;
        }
    }
}
