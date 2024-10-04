
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace parser_selenium
{
    internal class DB
    {
        SqlConnection connection = new SqlConnection(@"Data Source=Alexandr\SQLEXPRESS;initial Catalog=Items; Integrated Security = true");
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                Console.WriteLine("Connection was opened");
                connection.Open();
            }
        }
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Connection was closed");
                connection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }
        public void AddItemTypes(string Type,string Model)
        {
            SqlCommand cmd = new SqlCommand($"insert into Models(Type,Model) values('{Type}','{Model}')",GetConnection());

            OpenConnection();
            if (cmd.ExecuteNonQuery() == 1)
                Console.WriteLine("yeaaaaaah");
        }
    }
}
