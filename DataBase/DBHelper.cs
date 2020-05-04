using Jenkins2.DTO;
using MySql.Data.MySqlClient;
using System.Data;

namespace Jenkins2.DataBase
{
	public static class DBHelper
	{
		private static MySqlConnection dBConnection = new MySqlConnection("server=localhost;userid=root;pwd=root;database=jenkinstests");
		private static DataTable table;
		private static MySqlDataAdapter adapter;
		private static MySqlCommand command;

		private static void OpenConnection()
		{
			if (dBConnection.State == ConnectionState.Closed)
			{
				dBConnection.Open();
			}
		}

		private static void CloseConnection()
		{
			if (dBConnection.State == ConnectionState.Open)
			{
				dBConnection.Close();
			}
		}

		private static MySqlConnection GetConnection()
		{
			return dBConnection;
		}

		public static DataTable GetAllUsers()
		{
			OpenConnection();
			table = new DataTable();
			adapter = new MySqlDataAdapter();

			adapter.SelectCommand = new MySqlCommand("SELECT * FROM users", GetConnection());
			adapter.Fill(table);
			CloseConnection();
			return table;
		}
		public static DataTable ExecuteQuery(string queryString)
		{
			OpenConnection();
			table = new DataTable();
			adapter = new MySqlDataAdapter();

			adapter.SelectCommand = new MySqlCommand(queryString, GetConnection());
			adapter.Fill(table);

			CloseConnection();
			return table;
		}

		public static void RegisterUser(UserDTO user)
		{
			OpenConnection();
			command = new MySqlCommand($"INSERT INTO users (firstname, lastname) VALUES ('{user.name}', '{user.job}')", GetConnection());
			command.ExecuteNonQuery();
			CloseConnection();
		}

		public static void DeleteUser(UserDTO user)
		{
			OpenConnection();
			command = new MySqlCommand($"DELETE FROM users where firstname = '{user.name}'", GetConnection());
			command.ExecuteNonQuery();
			CloseConnection();
		}
	}
}
