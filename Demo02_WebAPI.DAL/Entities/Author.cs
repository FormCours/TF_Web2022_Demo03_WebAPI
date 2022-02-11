using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02_WebAPI.DAL.Entities
{
   public class Author
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      [Column("author_id", TypeName = "UNIQUEIDENTIFIER")]
      public Guid AuthorId { get; set; }

      [Required]
      [MaxLength(50)]
      [Column("firstname", TypeName = "NVARCHAR")]
      public string Firstname { get; set; }

      [Required]
      [MaxLength(50)]
      [Column("lastname", TypeName = "NVARCHAR")]
      public string Lastname { get; set; }

      public virtual ICollection<Book> Books { get; set; }
   }
}
