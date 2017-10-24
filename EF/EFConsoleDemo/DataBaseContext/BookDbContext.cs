using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using EFConsoleDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace EFConsoleDemo.DataBaseContext
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(p => p.Name);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=books.db");
        }
    }
}
