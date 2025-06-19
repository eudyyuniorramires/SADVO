using SADVO.Core.Application.Dtos.PartidoPolitico;
using SADVO.Core.Application.Dtos.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Dtos.DirigentePolitico
{
    public class DirigentePartidoDto
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public UsuarioDto? Usuario { get; set; }  // Para nombre y apellido

        public int PartidoPoliticoId { get; set; }
        public PartidoPoliticoDto? PartidoPolitico { get; set; }  // Para el nombre

        public string NombrePartido { get; set; }

    }
}
