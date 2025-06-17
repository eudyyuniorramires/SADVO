using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.ViewModels.LoginViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Ingrese el correo electrónico")]
        public required string UserName { get; set; }


        [Required(ErrorMessage ="Ingrese la contraseña")]
        [DataType(DataType.Password)]
        public required string Password { get; set; } 

        public string? MensajeError { get; set; }
    }
}
