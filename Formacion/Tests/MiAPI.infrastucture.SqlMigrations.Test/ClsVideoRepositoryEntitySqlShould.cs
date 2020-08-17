using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MiAPI.Business.Dtos;
using MiAPI.Infrastructure.Repository.Models;
using MiAPI.Infrastucture.SqlMigrations.Test;
using NUnit.Framework;

namespace MiAPI.Infrastructure.SqlRepository.Test {
    public class ClsVideoRepositoryEntitySqlShould : SqlTest {

        [Test]
        public async Task when_find_a_video_we_recover(){
            var videoClubContext = new VideoClubContext();
            var anyNameEntity = "AnyNameEntity";
            var anyFormatEntity = "AnyFormatEntity";
            AddNewVideo(videoClubContext, anyNameEntity, anyFormatEntity);
            var clsVideoRepositoryEntitySql = new ClsVideoRepositoryEntitySql(videoClubContext);

            var actualVideo =  await  clsVideoRepositoryEntitySql.Find(anyNameEntity);

            actualVideo.Should().BeEquivalentTo(new Video{name = anyNameEntity, format = anyFormatEntity });

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
