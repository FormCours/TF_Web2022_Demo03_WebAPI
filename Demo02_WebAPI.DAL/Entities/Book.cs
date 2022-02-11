using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02_WebAPI.DAL.Entities
{
   public class Book
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      [Column("book_id", TypeName = "UNIQUEIDENTIFIER")]
      public Guid BookId { get; set; }

      [Required]
      [MaxLength(250)]
      [Column("title", TypeName = "NVARCHAR")]
      public string Title { get; set; }

      [Column("nb_page", TypeName = "SMALLINT")]
      public int? NbPage { get; set; }


      public virtual ICollection<Author> Authors { get; set; }
   }
}
