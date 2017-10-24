using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EFWebDemo.Model;

namespace EFWebDemo.DataBaseContext
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuiler)
        {
            modelBuiler.Entity<Book>()
                .HasKey(p => p.Name);
        }


        public DbSet<Book> Books { get; set; }
    }
}