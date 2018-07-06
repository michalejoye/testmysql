using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ISLambdaCSharp.DAL
{
	public class Book
	{
		public string ISBN { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public string Language { get; set; }
		public int Pages { get; set; }
		public virtual Publisher Publisher { get; set; }
	}

	public class Publisher
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Book> Books { get; set; }
	}

	public class Sever
	{
		[Column(TypeName = "BINARY(16)")]
		public Guid SeverID { get; set; }
		public int CurrentCapaticy { get; set; }

		public int MaxCapaticy { get; set; }

	}
}
