using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using FluentAssertions;
using MiAPI.Business.Dtos;
using MiAPI.Infrastructure.SqlRepository;
using NUnit.Framework;

namespace MiAPI.Infrastucture.SqlMigrations.Test {
    public class ClsVideoRepositorySqlShould :SqlTest {
        [Test]
        public void when_try_find_a_video_we_can_recover() {
            CleanVideoTable();
            var video = GivenAVideo();
            var clsVideoRepositorySql = new ClsVideoRepositorySql(ConnectionString);
            clsVideoRepositorySql.Add(video);

            var actualVideo = clsVideoRepositorySql.Find(video.name);

            actualVideo.Should().BeEquivalentTo(video);
        }

        [Test]
        public void when_add_video_we_can_recover() {
            CleanVideoTable();
            var video = GivenAVideo();
            var clsVideoRepositorySql = new ClsVideoRepositorySql(ConnectionString);

            clsVideoRepositorySql.Add(video);

            ValidateIfExistNewVideo(video);
        }

        private static void ValidateIfExistNewVideo(Video video){
            var sqlDataAdapter = new SqlDataAdapter();
            var dt = new DataTable();
            System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter("select * from videos", ConnectionString);
            da.Fill(dt);

            dt.Rows.Should().HaveCount(1);
            dt.Rows[0]["name"].ToString().Should().Be(video.name);
            dt.Rows[0]["format"].ToString().Should().Be(video.format);
        }

        private static Video GivenAVideo(){
            return new Video{name="AnyName", format = "AnyFormat"};
        }

        private static void CleanVideoTable(){
            using (SqlConnection connection = new SqlConnection(
                ConnectionString)){
                SqlCommand command = new SqlCommand("truncate table videos", connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
