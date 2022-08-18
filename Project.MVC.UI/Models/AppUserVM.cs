using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.MVC.UI.Models
{
    public class AppUserVM
    {
        [Required(ErrorMessage = "kullanıcı zorunlu")]
        public string Username { get; set; }
        [Required(ErrorMessage = "şifre zorunlu")]
        public string Password { get; set; }
        public Guest Guest { get; set; }
    }
}