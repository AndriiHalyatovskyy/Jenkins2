using Jenkins2.Data;
using Jenkins2.DataBase;
using NUnit.Framework;

namespace Jenkins2.Tests
{
	public class DapperTest : BaseTest
	{

		[Test]
		public static void dapperTestOne()
		{
			UserFromDB user = DapperHelper.GetUserByName(UserRepository.GetSeniorUser());
			Assert.True(user.firstname.Equals("Oleg"));
			Assert.True(user.lastname.Equals("Senior TAQC"));
			DapperHelper.Transaction(UserRepository.GetAndriiUser());

			DapperHelper.ExecuteQuery("delete from users where id > '3'");
		}

	}
}
