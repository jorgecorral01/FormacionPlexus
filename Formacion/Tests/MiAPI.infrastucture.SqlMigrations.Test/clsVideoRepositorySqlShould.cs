using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using FluentAssertions;
using MiAPI.Business.Dtos;
using MiAPI.Infrastructure.SqlRepository;
using NUnit.Framework;

namespace MiAPI.Infrastucture.SqlMigrations.Test {
    public class clsVideoRepositorySqlShould :SqlTest {
        [Test]
        public void when_add_video_we_can_recover(){
            using(SqlConnection connection = new SqlConnection(
                ConnectionString)) {
                SqlCommand command = new SqlCommand("truncate table videos", connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            var video = new Video{name="AnyName", format = "AnyFormat"};
            var clsVideoRepositorySql = new ClsVideoRepositorySql(ConnectionString);

            clsVideoRepositorySql.Add(video);

            var sqlDataAdapter  = new SqlDataAdapter();
            var dt = new DataTable();
            System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter("select * from videos", ConnectionString);
            da.Fill(dt);

            dt.Rows.Should().HaveCount(1);
            dt.Rows[0]["name"].ToString().Should().Be(video.name);
            dt.Rows[0]["format"].ToString().Should().Be(video.format);

        }
    }
}
