using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebApplication2.DataBase
{
    public class ConnectDataBase
    {
        private readonly string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        public SqlConnection sqlConnection;

        public SqlConnection SetUpConnect()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }

        public SqlCommand SqlSetUpCommand(SqlConnection sqlConnection, string stringSqlCommand)
        {
            SqlCommand sqlCommand = new SqlCommand(stringSqlCommand, sqlConnection);
            return sqlCommand;
        }

        public SqlDataAdapter SelectAdapterCommand(string stringSqlCommand)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(stringSqlCommand, SetUpConnect());
            return sqlDataAdapter; 
        }

        public SqlDataReader SelectReaderCommand(string stringSqlCommand)
        {
            SqlDataReader dataReader = SqlSetUpCommand(SetUpConnect(), stringSqlCommand).ExecuteReader();
            return dataReader;
        }

        public SqlCommand OtherCommand(string stringSqlCommand)
        {
            return SqlSetUpCommand(SetUpConnect(), stringSqlCommand);
        }
    }
}