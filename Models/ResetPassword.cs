using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreativeTim.Argon.DotNetCore.Free.Models
{
    public class ResetPasswordViewModel
    {
         public string EmailAddress {get;set;}
         public string Password {get;set;}
         public string ConfirmPassword {get;set;}
         public string Token  {get;set;}

    }
}
