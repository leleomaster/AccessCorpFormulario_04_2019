using System.Configuration;
using System.Data.SqlClient;

namespace AccessCorpFormulario.Infrastructure.Database.Repository
{
    public class BaseRepository
    {
        private readonly string StringConnection;

        public BaseRepository()
        {
            StringConnection = ConfigurationManager.ConnectionStrings["databaseAccessCorp"].ConnectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(StringConnection);
        }
    }
}
