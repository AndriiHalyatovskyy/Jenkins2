using Dapper;
using Jenkins2.Data;
using Jenkins2.DTO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace Jenkins2.DataBase
{
	public class DapperHelper
	{

		/// <summary>
		/// Creates new MySQL connection
		/// </summary>
		private static MySqlConnection GetConnection()
		{
			return new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlBase"].ConnectionString);
		}

		/// <summary>
		/// Opens connection, if needed
		/// </summary>
		private static void OpenConnection(IDbConnection connection)
		{
			if (connection.State == ConnectionState.Closed)
			{
				connection.Open();
			}
		}

		/// <summary>
		/// Returns all users from DB
		/// </summary>
		public static List<UserFromDB> GetAll()
		{
			using (IDbConnection connection = GetConnection())
			{
				OpenConnection(connection);
				return connection.Query<UserFromDB>("select * from users").ToList();
			}
		}

		/// <summary>
		/// Gets user by firstname
		/// </summary>
		/// <param name="user">User to search in DB</param>
		public static UserFromDB GetUserByName(UserDTO user)
		{
			using (IDbConnection connection = GetConnection())
			{
				OpenConnection(connection);
				return connection.QuerySingle<UserFromDB>($"select * from users where firstname = '{user.name}'");
			}
		}

		/// <summary>
		/// Transaction example
		/// </summary>
		public static void Transaction(UserDTO user)
		{
			using (IDbConnection connection = GetConnection())
			{
				OpenConnection(connection);

				using (var transaction = connection.BeginTransaction())
				{
					connection.Execute($"INSERT INTO users (firstname, lastname) VALUES ('{user.name}', '{user.job}')");
					transaction.Commit();
				}
			}
		}

		/// <summary>
		/// Execute specified query
		/// </summary>
		/// <param name="queryString">Query which should be executed</param>
		public static void ExecuteQuery(string queryString)
		{
			using (IDbConnection connection = GetConnection())
			{
				OpenConnection(connection);
				connection.Execute(queryString);
			}
		}
	}
}
