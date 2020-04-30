using Jenkins2.RestFolder.Engines;

namespace Jenkins2.RestFolder
{
	public class API
	{
		public User user { get; private set; }

		public API()
		{
			user = new User();
		}
	}
}
