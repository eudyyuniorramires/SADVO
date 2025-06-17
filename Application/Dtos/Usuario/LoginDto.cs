using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Dtos.Usuario
{
    public class LoginDto
    {

        public required string UserName { get; set; }

        public required string Password { get; set; }

    }
}
