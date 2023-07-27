using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Entering {0} is mandatory.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Entering {0} is mandatory.")]
        public string Password { get; set; }
    }
}
