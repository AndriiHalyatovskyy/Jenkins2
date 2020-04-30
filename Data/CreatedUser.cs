using System;

namespace Jenkins2.Data
{
	public class CreatedUser
	{
		public string name { get; set; }
		public string job { get; set; }
		public string id { get; set; }
		public string token { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public DateTime createdAt { get; set; }
	}
}
