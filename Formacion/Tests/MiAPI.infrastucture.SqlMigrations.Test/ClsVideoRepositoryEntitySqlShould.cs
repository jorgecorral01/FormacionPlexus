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
            videoClubContext.Videos.Add(new Videos{
                Name = "AnyNameEntity",
                Format = "AnyFormatEntity",
                CreateDate = DateTime.Now
            });
            videoClubContext.SaveChanges();
            var clsVideoRepositoryEntitySql = new ClsVideoRepositoryEntitySql(videoClubContext);

            var actualVideo =  await  clsVideoRepositoryEntitySql.Find("AnyNameEntity");

            actualVideo.Should().BeEquivalentTo(new Video{name = "AnyNameEntity", format = "AnyFormatEntity" });

        }
    }
}
