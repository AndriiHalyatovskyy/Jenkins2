using Jenkins2.Data;
using Jenkins2.DataBase;
using NUnit.Framework;

namespace Jenkins2.Tests
{
	public class DatabaseTests : BaseTest
	{

		[Test]
		public void DataBaseTestOne()
		{
			DBHelper.RegisterUser(UserRepository.GetUserForUpdate());

			Assert.True(DBHelper.GetUserByName(UserRepository.GetUserForUpdate()).Rows.Count == 1);

			DBHelper.DeleteUser(UserRepository.GetUserForUpdate());

			Assert.True(DBHelper.GetUserByName(UserRepository.GetUserForUpdate()).Rows.Count == 0);
		}
	}
}
