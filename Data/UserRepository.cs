using Jenkins2.DTO;

namespace Jenkins2.Data
{
	/// <summary>
	/// Contains different users
	/// </summary>
	public abstract class UserRepository
	{
		private UserRepository() { }

		public static UserDTO GetAndriiUser()
		{
			return new UserDTO("Andrii", "Trainee TAQC", "eve.holt@reqres.in", "cityslicka");
		}

		public static UserDTO GetSeniorUser()
		{
			return new UserDTO("Oleg", "Senior TAQC", "eve.holt@reqres.in", "pistol");
		}

		public static UserDTO GetUserForUpdate()
		{
			return new UserDTO("morpheus", "zion resident", "", "");
		}
	}
}
