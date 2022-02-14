using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo02_WebAPI.ViewModels
{
   public class BookViewModel
   {
      public Guid BookId { get; set; }
      public string Title { get; set; }
      public int? NbPage { get; set; }

      public IEnumerable<AuthorViewModel> Authors { get; set; }
   }

   public class BookDataViewModel
   {
      [Required(AllowEmptyStrings = false)]
      [MaxLength(250)]
      public string Title { get; set; }
      public int? NbPage { get; set; }
   }

   public class BookDataWithAuthorsViewModel : BookDataViewModel
   {
      public IEnumerable<Guid> Authors { get; set; }
   }
}
