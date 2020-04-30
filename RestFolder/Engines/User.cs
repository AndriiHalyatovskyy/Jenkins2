using Jenkins2.Data;
using Jenkins2.DTO;
using Jenkins2.RestFolder.Core;

namespace Jenkins2.RestFolder.Engines
{
	public class User : RestCORE
	{
		public CreatedUser CreateUser(UserDTO user)
		{
			SetUri("api/user");
			CreatePostRequest()
				.AddParameter("name", user.name)
				.AddParameter("job", user.job);
			return GetContent<CreatedUser>(GetResponse());
		}

		public CreatedUser RegisterUser(UserDTO user)
		{
			SetUri("api/register");
			CreatePostRequest()
				.AddParameter("email", user.email)
				.AddParameter("password", user.password);
			return GetContent<CreatedUser>(GetResponse());
		}

		public UpdatedUser UpdateUser(UserDTO user)
		{
			SetUri("api/users/2");
			CreatePatchRequest()
				.AddParameter("name",user.name)
				.AddParameter("job",user.job);
			return GetContent<UpdatedUser>(GetResponse());
		}
	}
}
