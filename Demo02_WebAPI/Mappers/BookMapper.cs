using Demo02_WebAPI.DAL.Entities;
using Demo02_WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo02_WebAPI.Mappers
{
   internal static class BookMapper
   {

      internal static BookViewModel ToBookVM(this Book book)
      {
         return new BookViewModel()
         {
            BookId = book.BookId,
            Title = book.Title,
            NbPage = book.NbPage,
            Authors = book.Authors.Select(a => a.ToAuthorVM())
         };
      }

      internal static Book ToBookEntity(this BookDataViewModel vm)
      {
         return new Book()
         {
            Title = vm.Title,
            NbPage = vm.NbPage
         };
      } 
   }
}
