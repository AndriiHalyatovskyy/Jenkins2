using Jenkins2.Data;
using NUnit.Framework;
using System;

namespace Jenkins2.Tests
{
	public class RestTests : BaseTest
	{

		[Test]
		public void RestCreateTest()
		{
			var user = Rest.api.user.CreateUser(UserRepository.GetAndriiUser());
			Assert.AreEqual(user.job, "Trainee TAQC");
			Assert.AreEqual(user.name,"Andrii");
		}

		[Test]
		public void RestRegisterTest()
		{
			var user = Rest.api.user.RegisterUser(UserRepository.GetSeniorUser());
			Assert.False(user.token.Equals(null));
		}

		[Test]
		public void RestUpdateTest()
		{
			var user = Rest.api.user.UpdateUser(UserRepository.GetUserForUpdate());
			Assert.True(user.updatedAt.Day == DateTime.Today.Day);
		}
	}
}
