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
			DBHelper.RegisterUser(UserRepository.GetAndriiUser());

			Assert.True(DBHelper.GetAllUsers().Rows.Count == 1);

			DBHelper.DeleteUser(UserRepository.GetAndriiUser());

			Assert.True(DBHelper.GetAllUsers().Rows.Count == 0);
		}
	}
}
