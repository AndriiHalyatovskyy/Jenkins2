using Jenkins2.Data;
using Jenkins2.DataBase.EntityFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jenkins2.Tests
{
	public class EntityFrameWorkTest
	{
		private static string name = "Andrii";
		private AuthorFromDB author = new AuthorFromDB(name);

		[Test]
		public void TestOne()
		{
			using (LibraryContext context = new LibraryContext())
			{
				author.books.Add(new BookFromDB("My new book"));
				author.books.Add(new BookFromDB("My second book"));
				context.authors.Add(author);
				context.SaveChanges();
				author = context.authors.First(au => au.name.StartsWith("A"));

				Assert.AreEqual(author.name, name);

				List<BookFromDB> bu = context.books.Where(bu => bu.author.id == author.id).ToList();
				Assert.True(bu.Count == 2);
				context.authors.Remove(author);
				context.SaveChanges();

				author = context.authors.Where(au => au.name.StartsWith("A")).FirstOrDefault();

				Assert.AreEqual(author, null);

			}
		}
	}
}
