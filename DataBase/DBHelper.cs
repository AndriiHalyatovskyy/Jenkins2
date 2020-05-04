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

		/// <summary>
		/// Creates new connection to database
		/// </summary>
		private static void OpenConnection()
		{
			if (dBConnection.State == ConnectionState.Closed)
			{
				dBConnection.Open();
			}
		}

		/// <summary>
		/// Closes database connection, if exist
		/// </summary>
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

		/// <summary>
		/// Gets all users from DB
		/// </summary>
		/// <returns>All registered users</returns>
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

		/// <summary>
		/// Execute specified query
		/// </summary>
		/// <param name="queryString">Query which should be executed</param>
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

		/// <summary>
		/// Registers new user into DB
		/// </summary>
		/// <param name="user"> New user</param>
		public static void RegisterUser(UserDTO user)
		{
			OpenConnection();
			command = new MySqlCommand($"INSERT INTO users (firstname, lastname) VALUES ('{user.name}', '{user.job}')", GetConnection());
			command.ExecuteNonQuery();
			CloseConnection();
		}

		/// <summary>
		/// Deletes specified user
		/// </summary>
		/// <param name="user">User to delete</param>
		public static void DeleteUser(UserDTO user)
		{
			OpenConnection();
			command = new MySqlCommand($"DELETE FROM users where firstname = '{user.name}'", GetConnection());
			command.ExecuteNonQuery();
			CloseConnection();
		}
	}
}
