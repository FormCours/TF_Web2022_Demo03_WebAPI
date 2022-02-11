using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo02_WebAPI.ViewModels
{
   public class AuthorViewModel
   {
      public Guid AuthorId { get; set; }
      public string Firstname { get; set; }
      public string Lastname { get; set; }
   }

   public class AuthorDataViewModel
   {
      [Required(AllowEmptyStrings = false)]
      [MaxLength(50)]
      public string Firstname { get; set; }

      [Required(AllowEmptyStrings = false)]
      [MaxLength(50)]
      public string Lastname { get; set; }
   }
}
