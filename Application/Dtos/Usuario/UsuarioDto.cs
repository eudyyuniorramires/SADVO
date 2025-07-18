﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Dtos.Usuario
{
    public class UsuarioDto
    {
        public  int Id { get; set; }
        public  string Nombre { get; set; }
        public  string Apellido { get; set; }
        public  string Email { get; set; }

        public string? UserName { get; set; }   
        public  string ContrasenaHash { get; set; }
        public bool EstaActivo { get; set; }

        public int PartidoPoliticoId { get; set; } 

        public string Rol { get; set; }

        
    }
}
