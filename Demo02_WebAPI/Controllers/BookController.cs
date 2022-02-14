using Demo02_WebAPI.DAL;
using Demo02_WebAPI.DAL.Entities;
using Demo02_WebAPI.Mappers;
using Demo02_WebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo02_WebAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class BookController : ControllerBase
   {
      private readonly DataContext _DataContext;

      // Injection du DataContext
      public BookController(DataContext dataContext)
      {
         _DataContext = dataContext;
      }

      [HttpGet]
      public IActionResult GetAll()
      {
         IEnumerable<BookViewModel> books = _DataContext.Books
                                                .Include(b => b.Authors)
                                                .Select(b => b.ToBookVM());
         // Le include est possible via "Microsoft.EntityFrameworkCore"

         return Ok(books);
      }

      [HttpGet]
      [Route("{bookId:guid}")]
      public IActionResult GetById([FromRoute] Guid bookId)
      {
         BookViewModel book = _DataContext.Books
                                 .Include(b => b.Authors)
                                 .SingleOrDefault(b => b.BookId == bookId)
                                 ?.ToBookVM();
         // Opérateur "?."  → Null-Conditional Operator (Sucre syntaxique)
         // Permet d'evité l'execution du Mapper, si l'object obtenu est null

         if (book is null)
         {
            return NotFound();
         }

         return Ok(book);
      }

      [HttpPost]
      public IActionResult AddBookWithAuthors([FromBody] BookDataWithAuthorsViewModel book)
      {
         // IEnumerable<Guid> (AuthorID) → Author
         IEnumerable<Author> authors = _DataContext.Authors
                                         .Where(a => book.Authors
                                                      .Any(authorId => authorId == a.AuthorId)
                                               );

         // Check: Verrification que tous les auteurs ont été récuperé.
         if(authors.Count() != book.Authors.Count())
         {
            return BadRequest(new {
               Error = "Erreur avec les auteurs"
            });
         }

         // Ajout du livre dans la DB
         Book newBook = book.ToBookEntity();
         newBook.Authors = authors.ToList();

         _DataContext.Books.Add(newBook);
         _DataContext.SaveChanges();

         // Renvoi du nouveau livre
         return Ok(newBook.ToBookVM());
      }

      [HttpPut]
      [Route("{bookId}")]
      public IActionResult UpdateBook([FromRoute] Guid bookId, [FromBody] BookDataViewModel book)
      {
         // Récuperation des données à mettre à jours
         Book updateBook = book.ToBookEntity();
         updateBook.BookId = bookId;

         try
         {
            // Mise à jours des données dans la DB
            _DataContext.Books.Update(updateBook);
            _DataContext.SaveChanges();
         }
         catch (DbUpdateConcurrencyException e)
         {
            return BadRequest();
         }

         // Force Entity Framework à charger les auteurs des livres
         _DataContext.Books.Include(b => b.Authors).Load();

         // Envoi de la réponse
         return Ok(updateBook.ToBookVM());
      }

      [HttpDelete]
      [Route("{bookId:guid}")]
      public IActionResult DeleteBook([FromRoute] Guid bookId)
      {
         Book target = _DataContext.Books.Where(b => b.BookId == bookId).SingleOrDefault();

         if (target is null) 
         {
            return BadRequest(new
            {
               Error = "Le livre n'existe pas"
            });
         }

         // Modification de la DB
         _DataContext.Books.Remove(target);
         _DataContext.SaveChanges();

         // Envoi d'un réponse
         return NoContent();
      }
   }
}

