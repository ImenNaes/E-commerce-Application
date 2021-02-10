using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Models
{
    public class RegisterModel
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }      
        public String Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public Guid ActivationCode { get; set; }
    }
}