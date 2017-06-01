using Microsoft.EntityFrameworkCore;
using ServerBooksLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerBooksLib.Services
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        // alternative version with default constructor, pass sql connection with onconfiguring
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => base.OnConfiguring(optionsBuilder);

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().Property<string>("Title").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Book>().Property<string>("Publisher").HasMaxLength(40).IsRequired(false);
        }
    }
}
