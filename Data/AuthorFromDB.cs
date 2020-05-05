using System.Collections.Generic;

namespace Jenkins2.Data
{
	public class AuthorFromDB
	{
		public AuthorFromDB()
		{
		}

		public AuthorFromDB(string name)
		{
			this.name = name;
			books = new HashSet<BookFromDB>();
		}
		public int id { get; set; }
		public string name { get; set; }
		public ICollection<BookFromDB> books { get; set; }
	}
}
