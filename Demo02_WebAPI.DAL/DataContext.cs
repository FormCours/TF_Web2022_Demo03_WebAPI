using Demo02_WebAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02_WebAPI.DAL
{
   public class DataContext : DbContext
   {
      public DataContext(DbContextOptions options) : base(options) { }

      public virtual DbSet<Author> Authors { get; set; }
      public virtual DbSet<Book> Books { get; set; }


      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder.UseSqlServer();
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         // Utilisation de l'API Fluent pour initialiser les données
         modelBuilder.Entity<Author>().HasData(_InitialAuthors);
         modelBuilder.Entity<Book>().HasData(_InitialBooks);


         // Utilisation de l'API Fluent pour établir une Many-to-Many
         modelBuilder.Entity<Book>()
            .HasMany(book => book.Authors)
            .WithMany(author => author.Books)
            .UsingEntity(ba => ba.HasData(new
            {
               AuthorsAuthorId = _InitialAuthors[0].AuthorId,
               BooksBookId = _InitialBooks[0].BookId
            },
            new
            {
               AuthorsAuthorId = _InitialAuthors[1].AuthorId,
               BooksBookId = _InitialBooks[1].BookId
            },
            new
            {
               AuthorsAuthorId = _InitialAuthors[2].AuthorId,
               BooksBookId = _InitialBooks[1].BookId
            }));
      }

      private List<Author> _InitialAuthors = new List<Author>
      {
         new Author() { 
            AuthorId=Guid.NewGuid(), Firstname="Riri", Lastname="Duck"
         },
         new Author() { 
            AuthorId=Guid.NewGuid(), Firstname="Della", Lastname="Duck" 
         },
         new Author() { 
            AuthorId=Guid.NewGuid(), Firstname="Zaza", Lastname="Vanderquack" 
         },
         new Author() { 
            AuthorId=Guid.NewGuid(), Firstname="Gontran", Lastname="Bonheur" 
         }
      };

      private List<Book> _InitialBooks = new List<Book>
      {
         new Book()
         {
            BookId = Guid.NewGuid(), Title = "Hello World", NbPage = 42
         },
         new Book()
         {
            BookId = Guid.NewGuid(), Title = "Bonjour", NbPage = null
         }
      };

   }
}
