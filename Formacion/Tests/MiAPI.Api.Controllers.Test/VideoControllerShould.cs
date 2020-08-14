using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MiAPI.Business.Dtos;
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

        [Test]
        public async Task when_we_ask_for_find_a_video_we_obtain() {
            var expectedVideo = ForGivenData(out var client, out var requestUri);
            
            var result = await client.GetAsync(requestUri);

            var actualVideo = Newtonsoft.Json.JsonConvert.DeserializeObject<Video>(result.Content.ReadAsStringAsync().Result);
            actualVideo.Should().BeEquivalentTo(expectedVideo);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task should_return_not_found_when_we_ask_for_find_a_not_existing_video() {
            var anyVideoThatNotExist = "Any video that not exist";
            var expectedVideo = ForGivenNoExistingData(out var client, out var requestUri, anyVideoThatNotExist);

            var result = await client.GetAsync(requestUri);
            
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
            var actualVideo = Newtonsoft.Json.JsonConvert.DeserializeObject<Video>(result.Content.ReadAsStringAsync().Result);
            actualVideo.name.Should().Be(anyVideoThatNotExist);
        }

        private object ForGivenNoExistingData(out HttpClient client , out string requestUri, string nombreVideoABuscar) {
            var expectedVideo = new Video { format = "avi", name = nombreVideoABuscar };
            client = new HttpClient();
            requestUri = string.Format("http://localhost:35555/api/video/{0}", nombreVideoABuscar);
            return expectedVideo;
        }
        
        [Test]
        public async Task get_all_videos_and_users() {
            HttpClient client = new HttpClient();
            string requestUri = "http://localhost:35555/api/Video/VideosAndUsers";
            
            var result =  await client.GetAsync(requestUri);
            var actualData = Newtonsoft.Json.JsonConvert.DeserializeObject<DataList>(result.Content.ReadAsStringAsync().Result);

            actualData.Should().BeEquivalentTo(new DataList{Users =  new List<User>(),Videos = new List<Video>()});
            result.StatusCode.Should().Be(HttpStatusCode.OK);
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

        private static void GivenAVideo(out Video expectedVideo) {
            expectedVideo = new Video { format = "avi", name = "fiesta" };
        }

        private static HttpContent GivenAHttpContent(Video expectedVideo, string requestUri) {
            string jsonVideo = JsonConvert.SerializeObject(expectedVideo, Formatting.Indented);
            HttpContent content = new StringContent(jsonVideo, Encoding.UTF8, "application/json");
            HttpRequestMessage request = new HttpRequestMessage {
                Method = HttpMethod.Post,
                RequestUri = new Uri(requestUri),
                Content = content
            };
            return content;
        }
    }
}
