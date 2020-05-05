using System.ComponentModel.DataAnnotations;

namespace Jenkins2.Data
{
	public class BookFromDB
	{
		public BookFromDB()
		{
		}

		public BookFromDB(string title)
		{
			this.title = title;
		}

		public int id { get; set; }
		public string title { get; set; }

		[Required]
		public AuthorFromDB author { get; set; }
	}
}
