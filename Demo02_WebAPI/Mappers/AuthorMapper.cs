using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Demo02_WebAPI.DAL.Entities;
using Demo02_WebAPI.ViewModels;

namespace Demo02_WebAPI.Mappers
{
   internal static class AuthorMapper
   {
      // Création d'une méthode d'extension sur l'objet "Author"
      internal static AuthorViewModel ToAuthorVM(this Author author)
      {
         // Transferer l'objet "Author" dans "AuthorViewModel"
         return new AuthorViewModel()
         {
            AuthorId = author.AuthorId,
            Firstname = author.Firstname,
            Lastname = author.Lastname
         };
      }

      internal static Author ToAuthorEntity(this AuthorDataViewModel vm)
      {
         return new Author()
         {
            Firstname = vm.Firstname,
            Lastname = vm.Lastname
         };
      }
   }
}
