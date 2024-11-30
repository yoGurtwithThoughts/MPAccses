using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;

namespace MPAccses.MVVM.DB
{
    public class ConnectDB
    {
        private string _connectionString;
        public ConnectDB() {
            _connectionString = ConfigurationManager.ConnectionStrings["ISMPEntities"].ConnectionString;
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
