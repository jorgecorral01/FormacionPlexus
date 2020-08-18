using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MiAPI.Business.Dtos;
using MiAPI.Infrastructure.Repository.Models;
using MiAPI.Infrastucture.SqlMigrations.Test;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace MiAPI.Infrastructure.SqlRepository.Test {
    public class ClsVideoRepositoryEntitySqlShould : SqlTest {
        private VideoClubContext videoClubContext;

        

        [SetUp]
        public void SetUp() {
            var optionsBuilder = new DbContextOptionsBuilder<VideoClubContext>()
                .UseInMemoryDatabase(databaseName: "BDInMemory")
                .Options;

            videoClubContext = new VideoClubContext(optionsBuilder);
        }
        [Test]
        public async Task when_find_a_video_we_recover(){
            
            var anyNameEntity = "AnyNameEntity2";
            var anyFormatEntity = "AnyFormatEntity2";
            AddNewVideo(videoClubContext, anyNameEntity, anyFormatEntity);
            var clsVideoRepositoryEntitySql = new ClsVideoRepositoryEntitySql(videoClubContext);

            var actualVideo =  await  clsVideoRepositoryEntitySql.Find(anyNameEntity);

            actualVideo.Should().BeEquivalentTo(new Video{name = anyNameEntity, format = anyFormatEntity });
            //DeleteNewVideo(videoClubContext);
        }

        private static void DeleteNewVideo(VideoClubContext videoClubContext){
            var videosToRemove = videoClubContext.Videos.FirstOrDefault(item => item.Name == "AnyNameEntity");
            videoClubContext.Videos.RemoveRange(videosToRemove);
            videoClubContext.SaveChanges();
        }

        private static void AddNewVideo(VideoClubContext videoClubContext, string anyNameEntity, string anyFormatEntity){
            videoClubContext.Videos.Add(new Videos{
                Name = anyNameEntity,
                Format = anyFormatEntity,
                CreateDate = DateTime.Now
            });
            videoClubContext.SaveChanges();
        }
    }
}
