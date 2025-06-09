using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Domain.Entities
{
    public class DirigentePartido
    {
        public required int Id { get; set; }

        public required int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }

        public required int PartidoPoliticoId { get; set; }
        public required PartidoPolitico PartidoPolitico { get; set; }
    }
}
