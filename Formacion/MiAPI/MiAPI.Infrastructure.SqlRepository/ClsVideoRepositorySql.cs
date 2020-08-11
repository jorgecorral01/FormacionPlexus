using System.Data;
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

        public virtual void Add(Video video){
            using(SqlConnection connection = new SqlConnection(
                _connectionString)) {
                SqlCommand command = new SqlCommand(string.Format("insert into videos (name, format) values('{0}','{1}')", video.name, video.format), connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Video Find(string name){
                var sqlDataAdapter = new SqlDataAdapter();
                var dt = new DataTable();
                System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter(string.Format("Select * from Videos where name = '{0}'", name), _connectionString);
                da.Fill(dt);
                return CreateNewVideoWithDT(dt);
        }

        private static Video CreateNewVideoWithDT(DataTable dt){
            return new Video{name = dt.Rows[0]["name"].ToString(), format = dt.Rows[0]["format"].ToString() };
        }
    }
}