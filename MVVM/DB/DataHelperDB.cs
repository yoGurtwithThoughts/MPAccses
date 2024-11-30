using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAccses.MVVM.DB
{
    public class DataHelperDB
    {
        private readonly ConnectDB _databaseConnection;
        public DataHelperDB() {
            _databaseConnection = new ConnectDB();
        }
        public DataTable GetDataFromTable(string tableName)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = _databaseConnection.GetConnection())
            {
                connection.Open();
                string query = $"SELECT * FROM {tableName}"; 

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
                {
                    dataAdapter.Fill(dt);
                }
            }

            return dt;
        }
        public void InsertDataIntoTable(string tableName, Dictionary<string, object> data)
        {
            using (SqlConnection connection = _databaseConnection.GetConnection())
            {
                connection.Open();
                string columns = string.Join(", ", data.Keys);
                string parameters = string.Join(", ", data.Keys.Select(key => "@" + key));

                string insertQuery = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    foreach (var entry in data)
                    {
                        command.Parameters.AddWithValue("@" + entry.Key, entry.Value ?? DBNull.Value);
                    }

                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateDataInTable(string tableName, Dictionary<string, object> data, string whereCondition)
        {
            using (SqlConnection connection = _databaseConnection.GetConnection())
            {
                connection.Open();

                string setClause = string.Join(", ", data.Keys.Select(key => $"{key} = @{key}"));

                string updateQuery = $"UPDATE {tableName} SET {setClause} WHERE {whereCondition}";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                   
                    foreach (var entry in data)
                    {
                        command.Parameters.AddWithValue("@" + entry.Key, entry.Value ?? DBNull.Value);
                    }

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
