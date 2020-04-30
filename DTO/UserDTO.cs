namespace Jenkins2.DTO
{
	/// <summary>
	/// Data transport object
	/// </summary>
	public class UserDTO
	{
		public UserDTO(string name, string job, string email, string password)
		{
			this.name = name;
			this.job = job;
			this.email = email;
			this.password = password;
		}

		public string name { get; set; }
		public string job { get; set; }
		public string email { get; set; }
		public string password { get; set; }
	}
}
