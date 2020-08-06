using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using MiAPI.Business.Dtos;
using NUnit.Framework;

namespace MiAPI.Api.Controllers.Test{
    public class VideoControllerShould{
        [Test]
        public async Task when_we_ask_for_a_video_we_obtein(){
            var nombreVideoABuscar = "fiesta";
            HttpClient client = new HttpClient();
            var requestUri = string.Format("https://localhost:44314/api/Video/{0}", nombreVideoABuscar);
            
            var result = await client.GetAsync(requestUri);
            var actualVideo = Newtonsoft.Json.JsonConvert.DeserializeObject<Video>(result.Content.ReadAsStringAsync().Result);
            
            var expectedVideo = new Video{format = "jpg", name = "fiesta" };
            actualVideo.Should().BeEquivalentTo(expectedVideo);


        }
    }
}
