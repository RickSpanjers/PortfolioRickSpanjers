using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Contexts
{

	public class ConnectionHelper
	{
		public SqlConnection ReturnSQLConnection()
		{
			SqlConnection cnn = new SqlConnection(Startup.Connectionstring);

			if (cnn.State != ConnectionState.Open)
			{
				cnn.Open();
			}

			return cnn;
		}

		public MySqlConnection ReturnMYSQLConnection()
		{
			MySqlConnection cnn = new MySqlConnection(Startup.Connectionstring);

			if (cnn.State != ConnectionState.Open)
			{
				cnn.Open();
			}

			return cnn;
		}

		public SqlCommand CreateSQLCommandText(string query, SqlConnection connection)
		{
			SqlConnection cnn = connection;
			var cmd = cnn.CreateCommand();
			cmd.Connection = cnn;
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = query;
			return cmd;
		}

		public MySqlCommand CreateMYSQLCommandText(string query, MySqlConnection connection)
		{
			MySqlConnection cnn = connection;
			var cmd = cnn.CreateCommand();
			cmd.Connection = cnn;
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = query;
			return cmd;
		}

		public SqlCommand CreateSQLCommandStoredProcedure(string procedure, SqlConnection connection)
		{
			SqlConnection cnn = connection;
			SqlCommand cmd = new SqlCommand(procedure, cnn);
			cmd.CommandType = CommandType.StoredProcedure;
			return cmd;
		}

		public MySqlCommand CreateMYSQLCommandStoredProcedure(string procedure, MySqlConnection connection)
		{
			MySqlConnection cnn = connection;
			MySqlCommand cmd = new MySqlCommand(procedure, cnn);
			cmd.CommandType = CommandType.StoredProcedure;
			return cmd;
		}
	}
}
