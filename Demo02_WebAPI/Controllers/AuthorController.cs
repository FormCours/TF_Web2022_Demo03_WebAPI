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
   public class AuthorController : ControllerBase
   {
      private readonly DataContext _DataContext;

      // ↓ Utilisation de l'injection de dependence pour obtenir le DataContext
      public AuthorController(DataContext dataContext)
      {
         _DataContext = dataContext;
      }


      // GET: api/author
      [HttpGet]
      public IActionResult GetAll()
      {
         // Récuperation des datas via EntityFramework
         IEnumerable<Author> authors = _DataContext.Authors;

         // Mapping du Model "DAL" vers le ViewModel
         IEnumerable<AuthorViewModel> authorViews = authors
               .Select(a => a.ToAuthorVM());


         // Resultat de l'API
         return Ok(authorViews);
      }


      // POST: api/author
      [HttpPost]
      public IActionResult AddAuthor([FromBody] AuthorDataViewModel author)
      {
         // TODO Add check if author is unique

         // Création d'un nouvelle objet "db" (Via le mapper)
         Author newAuthor = author.ToAuthorEntity();

         // Ajout en DB
         _DataContext.Authors.Add(newAuthor);
         _DataContext.SaveChanges();

         // Reponse de l'api
         return Ok(new
         {
            authorId = newAuthor.AuthorId
         });
      }


      // GET: api/author/{authorId}      (Obtenir les infos d'un auteur)
      [HttpGet]
      [Route("{authorId:guid}")] // Parametre de route typé
      public IActionResult GetById(Guid authorId)
      {
         // Récuperation des données via EntityFramework
         Author author = _DataContext.Authors.SingleOrDefault(
            a => a.AuthorId == authorId
         );

         // Si aucunne donnée n'a été trouvé => Erreur 404
         if (author is null)
         {
            return NotFound();
         }

         // Utilisation d'un mapper pour convertir une entité vers le ViewModel
         return Ok(author.ToAuthorVM());
      }


      // PUT:     (Mise à jours d'un auteur)
      [HttpPut]
      [Route("{authorId:guid}")]
      public IActionResult UpdateAuthor(Guid authorId, [FromBody] AuthorDataViewModel author)
      {
         // Mise à jours des données
         Author updateAuthor = author.ToAuthorEntity();
         updateAuthor.AuthorId = authorId;

         try
         {
            // On donne l'objet "author" avec un "etat" modifié (→ Update)
            _DataContext.Entry(updateAuthor).State = EntityState.Modified;

            // Entity framework réalise la mise a jours sur base de la PK
            _DataContext.SaveChanges();
         }
         catch (DbUpdateConcurrencyException e)
         {
            // Exception produite lors d'une erreur durant un update
            return BadRequest();
         }

         return Ok(updateAuthor.ToAuthorVM());
      }


      // DELETE:  (Suppression)
      [HttpDelete]
      [Route("{authorId}")]
      public IActionResult DeleteAuthor(Guid authorId)
      {
         Author target = _DataContext.Authors.Where(a => a.AuthorId == authorId)
                                             .SingleOrDefault();

         if (target is null)
         {
            return BadRequest(new { Error = "L'auteur n'existe pas" });
         }

         // On retire l'element via Entity Framework
         _DataContext.Authors.Remove(target);
         //_DataContext.Entry(target).State = EntityState.Deleted;

         // On réalise les changmeents
         _DataContext.SaveChanges();

         return NoContent();
      }


      // GET:     (Obtenir les auteurs sur base d'une recherche
      //           sur leur nom ou prenom)
      [HttpGet]
      [Route("search")]
      public IActionResult SearchAuthor([FromQuery] string name)
      {
         // Test de garde => Pas de recherche vide!
         if(string.IsNullOrWhiteSpace(name))
         {
            return BadRequest(new { Error = "Veuillez encoder une valeur :o" });
         }

         // Recherche via du LINQ et un mapping vers le type "ViewModel"
         IEnumerable<AuthorViewModel> authors = _DataContext.Authors
                  .Where(a => a.Firstname.Contains(name) || a.Lastname.Contains(name))
                  .Select(a => a.ToAuthorVM());

         // Envoie des resultats
         return Ok(authors);
      }
   }
}
