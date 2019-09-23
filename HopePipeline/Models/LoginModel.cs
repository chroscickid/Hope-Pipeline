using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HopePipeline.Models;

namespace HopePipeline.Models.ViewModels
{
    public class LoginModel
    {
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [UIHint("Password")]
        public string Password { get; set; }

        public string returnUrl { get; set; } = "/";
    }
}
