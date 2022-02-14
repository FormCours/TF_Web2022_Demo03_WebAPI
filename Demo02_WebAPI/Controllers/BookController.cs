using Demo02_WebAPI.DAL;
using Demo02_WebAPI.DAL.Entities;
using Demo02_WebAPI.Mappers;
using Demo02_WebAPI.ResponseModel;
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
      // ↓ Permet de définir le type de retour en fonction du status (Swagger)
      [ProducesResponseType(200, Type = typeof(IEnumerable<BookViewModel>))]
      public async Task<IActionResult> GetAll()
      {
         // Pour traitement lourd (Calc/DB)
         // => Il est recommander d'utiliser de l'asynchrone
          IEnumerable<BookViewModel> books = await _DataContext.Books
                                                   .Include(b => b.Authors)
                                                   .Select(b => b.ToBookVM())
                                                   .ToListAsync();
         // Le include est possible via "Microsoft.EntityFrameworkCore"

         return Ok(books);
      }

      [HttpGet]
      [Route("{bookId:guid}")]
      [ProducesResponseType(200, Type= typeof(BookViewModel))]
      [ProducesResponseType(404, Type = typeof(ErrorResponse))]
      public async Task<IActionResult> GetById([FromRoute] Guid bookId)
      {
         Book bookDB = await _DataContext.Books
                        .Include(b => b.Authors)
                        .SingleOrDefaultAsync(b => b.BookId == bookId);

         BookViewModel book = bookDB?.ToBookVM();
         // Opérateur "?."  → Null-Conditional Operator (Sucre syntaxique)
         // Permet d'evité l'execution du Mapper, si l'object obtenu est null

         if (book is null)
         {
            return NotFound(new ErrorResponse(404, "Book not found"));
         }

         return Ok(book);
      }

      [HttpPost]
      [ProducesResponseType(200, Type= typeof(BookViewModel))]
      [ProducesResponseType(400, Type = typeof(ErrorResponse))]
      public async Task<IActionResult> AddBookWithAuthors([FromBody] BookDataWithAuthorsViewModel book)
      {
         if(book.Authors == null)
         {
            return BadRequest(new ErrorResponse("The \"authors\" property is required"));
         }

         // IEnumerable<Guid> (AuthorID) → Author
         IEnumerable<Author> authors = await _DataContext.Authors
                                          .Where(a => book.Authors
                                              .Any(authorId => authorId == a.AuthorId)
                                                )
                                          .ToListAsync();

         // Check: Verrification que tous les auteurs ont été récuperé.
         if(authors.Count() != book.Authors.Count())
         {
            return BadRequest(new ErrorResponse("Error with author values"));
         }

         // Conversion du "Book VM" en "Book Entity"
         Book newBook = book.ToBookEntity();

         // Ajout des auteurs dans le nouveau livre
         newBook.Authors = authors.ToList();

         _DataContext.Books.Add(newBook);
         _DataContext.SaveChanges();

         // Renvoi du nouveau livre
         return Ok(newBook.ToBookVM());
      }

      [HttpPut]
      [Route("{bookId}")]
      [ProducesResponseType(200, Type = typeof(BookViewModel))]
      [ProducesResponseType(400, Type = typeof(ErrorResponse))]
      public async Task<IActionResult> UpdateBook([FromRoute] Guid bookId, [FromBody] BookDataViewModel book)
      {
         // Récuperation des données à mettre à jours
         Book updateBook = book.ToBookEntity();
         updateBook.BookId = bookId;

         try
         {
            // Mise à jours des données dans la DB
            _DataContext.Books.Update(updateBook);
            await _DataContext.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException e)
         {
            return BadRequest(new ErrorResponse("Conflict Book"));
         }

         // Force Entity Framework à charger les auteurs des livres
         _DataContext.Books.Include(b => b.Authors).Load();

         // Envoi de la réponse
         return Ok(updateBook.ToBookVM());
      }

      [HttpDelete]
      [Route("{bookId:guid}")]
      [ProducesResponseType(204)]
      [ProducesResponseType(400, Type = typeof(ErrorResponse))]
      public async Task<IActionResult> DeleteBook([FromRoute] Guid bookId)
      {
         Book target = _DataContext.Books.Where(b => b.BookId == bookId).SingleOrDefault();

         if (target is null) 
         {
            return BadRequest(new ErrorResponse("Book not found"));
         }

         // Modification de la DB
         _DataContext.Books.Remove(target);
         await _DataContext.SaveChangesAsync();

         // Envoi d'un réponse
         return NoContent();
      }

      [HttpGet]
      [Route("Search")]
      [ProducesResponseType(200, Type = typeof(IEnumerable<BookViewModel>))]
      [ProducesResponseType(400, Type = typeof(ErrorResponse))]
      public async Task<IActionResult> SearchBook([FromQuery] string title)
      {
         if(string.IsNullOrWhiteSpace(title))
         {
            return BadRequest(new ErrorResponse("Invalide value"));
         }

         IEnumerable<BookViewModel> books = await _DataContext.Books
                                                .Include(b => b.Authors)
                                                .Where(b => b.Title.Contains(title))
                                                .Select(b => b.ToBookVM())
                                                .ToListAsync();

         return Ok(books);
      }

      [HttpGet]
      [Route("Search/Author")]
      [ProducesResponseType(200, Type = typeof(IEnumerable<BookViewModel>))]
      [ProducesResponseType(400, Type = typeof(ErrorResponse))]
      public async Task<IActionResult> SearchBookByAuthor([FromQuery] string authorName)
      {
         if (string.IsNullOrWhiteSpace(authorName))
         {
            return BadRequest(new ErrorResponse("Invalide value"));
         }

         IEnumerable<BookViewModel> books = await _DataContext.Books
                                             .Include(b => b.Authors)
                                             .Where(b => b.Authors.Any(
                                                a => a.Firstname.Contains(authorName)
                                                   || a.Lastname.Contains(authorName)))
                                             .Select(b => b.ToBookVM())
                                             .ToListAsync();

         return Ok(books);
      }
   }
}

