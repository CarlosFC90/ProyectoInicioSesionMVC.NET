using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoInicioSesionMVC.Models.ViewModel
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 10)]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Display(Name = "Confirma Contraseña")]
        [Compare("Password", ErrorMessage ="Las contraseñas ingresadas no son iguales")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        public int Edad { get; set; }
    }

    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 10)]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirma Contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas ingresadas no son iguales")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int Edad { get; set; }
    }
}