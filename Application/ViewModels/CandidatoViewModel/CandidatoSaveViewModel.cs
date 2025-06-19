using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.ViewModels.CandidatoViewModel
{
    public class CandidatoSaveViewModel
    {
        public required int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string FotoPath { get; set; }
        public bool EstaActivo { get; set; }

        public string PartidoPoliticoNombre { get; set; } = string.Empty;

        public int PartidoPoliticoId { get; set; }
    }
}
