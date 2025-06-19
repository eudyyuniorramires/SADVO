using SADVO.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Domain.Interfaces
{
    public interface IEleccionesRepository : IGenericRepository<Eleccion> 
    {
        Task<bool> ExisteEleccionActivaAsync();

    }
}
