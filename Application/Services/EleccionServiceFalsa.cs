using SADVO.Core.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Services
{
    public class EleccionServiceFalsa : IEleccionesService
    {
        public Task<bool> ExisteEleccionActivaAsync()
        {
            // Temporalmente devolvemos false para permitir todas las operaciones
            return Task.FromResult(false);
        }
    }

}
