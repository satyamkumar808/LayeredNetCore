using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class RegisterUser
    {
        [Required(ErrorMessage ="User name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password cannot be blank")]
        public string Password { get; set; }

        public string Email { get; set; }
    }
}
