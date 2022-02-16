using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(16)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(30)]
        public string Password { get; set; }
    }
}