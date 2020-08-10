using System.Data.SqlClient;
using System.Threading.Tasks;
using MiAPI.Business.Dtos;
using MiAPI.Business.IRepositories;

namespace MiAPI.Infrastructure.SqlRepository{
    public class ClsVideoRepositorySql : IClsVideoRepository {
        private readonly string _connectionString;

        public ClsVideoRepositorySql(string connectionString){
            _connectionString = connectionString;
            
        }

        public void Add(Video video){
            using(SqlConnection connection = new SqlConnection(
                _connectionString)) {
                SqlCommand command = new SqlCommand(string.Format("insert into videos (name, format) values('{0}','{1}')", video.name, video.format), connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Task<Video> Find(string name){
            throw new System.NotImplementedException();
        }
    }
}