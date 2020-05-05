namespace Jenkins2.DataBase.EntityFramework
{
	using Jenkins2.Data;
	using System.Data.Entity;

	public class LibraryContext : DbContext
	{
		public DbSet<BookFromDB> books { get; set; }
		public DbSet<AuthorFromDB> authors { get; set; }

		public LibraryContext()
			: base("name=LibraryContext")
		{
		}
	}
}