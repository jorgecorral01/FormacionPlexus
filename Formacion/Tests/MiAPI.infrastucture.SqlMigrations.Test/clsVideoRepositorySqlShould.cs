﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using FluentAssertions;
using MiAPI.Business.Dtos;
using MiAPI.Infrastucture.SqlMigrations.Test;
using NUnit.Framework;

namespace MiAPI.Infrastructure.SqlRepository.Test {
    public class ClsVideoRepositorySqlShould :SqlTest {
        private Video video;
        private ClsVideoRepositorySql clsVideoRepositorySql;

        [SetUp]
        public void Setup() {
            video = GivenAVideo();
            clsVideoRepositorySql = new ClsVideoRepositorySql(ConnectionString);
        }
        [Test]
        public async Task when_try_find_a_video_we_can_recover() {
            CleanVideoTable();
            clsVideoRepositorySql.Add(video);

            var actualVideo = await clsVideoRepositorySql.Find(video.name);

            actualVideo.Should().BeEquivalentTo(video);
        }

        [Test]
        public void should_throw_video_not_found_exception_when_try_find_a_video_and_not_exist() {
            
            Func<Task> action = async () => await clsVideoRepositorySql.Find("AnyVideoName");

            action.Should().ThrowExactly<VideoNotFoundException>()
                .And.Name.Should().Be("AnyVideoName");
        }

        [Test]
        public void when_add_video_we_can_recover() {
            CleanVideoTable();

            clsVideoRepositorySql.Add(video);

            ValidateIfExistNewVideo(video);
        }

        [Test]
        public void we_should_return_existing_video_exception_when_try_add_existing_video() {
            CleanVideoTable();
            clsVideoRepositorySql.Add(video);

            var ex = Assert.Throws<VideoAlreadyExistException>(() => clsVideoRepositorySql.Add(video));

            ex.Should().BeOfType<VideoAlreadyExistException>();
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
