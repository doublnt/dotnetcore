using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using EFConsoleDemo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFConsoleDemo.DatabaseContext
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one-to-one relationship
            modelBuilder.Entity<Book>()
                .HasOne(p => p.Authors)
                .WithOne(p => p.Books)
                .HasForeignKey<Author>(p => p.AuthorId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=books.db");
        }
    }
}
