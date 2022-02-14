using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo02_WebAPI.ResponseModel
{
   public class ErrorResponse
   {
      public int Code { get; set; }
      public string Message { get; set; }

      public ErrorResponse(int code, string message)
      {
         this.Code = code;
         this.Message = message;
      }

      public ErrorResponse(string message)
         : this(400, message) 
      { }
   }
}
