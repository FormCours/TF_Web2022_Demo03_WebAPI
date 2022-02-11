using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02_WebAPI.DAL.Entities
{
   // Permet de créer une « Many to many » en utilisant les « Data annotations »
   // -> Necessite l'ajout d'un props de navigation sur les elements "liés"
   //    Et l'ajout dans le DbContext.

   // NOTE: Dans la demo, on utilise l'API Fluent.

   /*
   public class AuthorBook
   {
      [Key, Column("author_id", Order = 1, TypeName = "UNIQUEIDENTIFIER")]
      public Guid AuthorId { get; set; }

      [Key, Column("book_id", Order = 2, TypeName = "UNIQUEIDENTIFIER")]
      public Guid BookId { get; set; }


      [ForeignKey(nameof(AuthorId))]
      public Author Author { get; set; }

      [ForeignKey(nameof(BookId))]
      public Book Book { get; set; }
   }
   */
}
