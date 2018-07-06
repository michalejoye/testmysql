using System;
using Microsoft.EntityFrameworkCore;

namespace ISLambdaCSharp.DAL
{
	public class ISContext : DbContext
	{
		public DbSet<Book> Book { get; set; }

		public DbSet<Publisher> Publisher { get; set; }

		public DbSet<Sever> Severs { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySql("server=localhost;database=innersanctum;user=innersanctum;password=innersanctum;SslMode=none");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Publisher>(entity =>
			{
				entity.HasKey(e => e.ID);
				entity.Property(e => e.Name).IsRequired();
			});

			modelBuilder.Entity<Book>(entity =>
			{
				entity.HasKey(e => e.ISBN);
				entity.Property(e => e.Title).IsRequired();
				entity.HasOne(d => d.Publisher)
				  .WithMany(p => p.Books);
			});
			modelBuilder.Entity<Sever>(entity =>
			{
				entity.HasKey(e => e.SeverID).HasAnnotation("Column",new { TypeName= "BINARY(16)"});
				entity.Property(e => e.MaxCapaticy).HasDefaultValue(100);
			});
		}
	}
}
