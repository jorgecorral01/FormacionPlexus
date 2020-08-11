using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MiAPI.Business.Dtos;
using MiAPI.Repositories;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Discovery;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;

namespace MiAPI.Api.Controllers.Test{
    public class VideoControllerShould{

        [Test]
        public async Task when_we_add_a_video_we_obtain_response_ok() {
            GivenAVideo(out var expectedVideo);
            HttpClient client = new HttpClient();
            var requestUri = "http://localhost:35555/api/video";
            var content = GivenAHttpContent(expectedVideo, requestUri);

            var result =  await  client.PostAsync(requestUri, content);

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        private static void GivenAVideo(out Video expectedVideo){
            expectedVideo = new Video{format = "avi", name = "fiesta" };
        }

        private static HttpContent GivenAHttpContent(Video expectedVideo, string requestUri){
            string jsonVideo = JsonConvert.SerializeObject(expectedVideo, Formatting.Indented);
            HttpContent content = new StringContent(jsonVideo, Encoding.UTF8, "application/json");
            HttpRequestMessage request = new HttpRequestMessage{
                Method = HttpMethod.Post,
                RequestUri = new Uri(requestUri),
                Content = content
            };
            return content;
        }

        [Test]
        public async Task when_we_ask_for_a_video_we_obtain() {
            var expectedVideo = ForGivenData(out var client, out var requestUri);

            var actualVideo = await FindVideo(client, requestUri);

            actualVideo.Should().BeEquivalentTo(expectedVideo);
            //await client.ShouldResponse().Ok();
        }
        
        [Ignore("wip")]
        [Test]
        public async Task get_all_videos_and_users() {
            var expectedVideo = ForGivenData(out var client, out var requestUri);

            var actualVideo = await FindVideo(client, requestUri);

            actualVideo.Should().BeEquivalentTo(expectedVideo);
            //await client.ShouldResponse().Ok();
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
