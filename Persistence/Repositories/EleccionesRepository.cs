using Microsoft.EntityFrameworkCore;
using SADVO.Core.Domain.Entities;
using SADVO.Core.Domain.Interfaces;
using SADVO.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Infrastructure.Persistence.Repositories
{
    public class EleccionRepository : GenericRepository<Eleccion>, IEleccionesRepository
    {
        private readonly ApplicationDbContext _context;

        public EleccionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExisteEleccionActivaAsync()
        {
            return await _context.Elecciones.AnyAsync(e => e.Estado == EstadoEleccion.EnProceso);
        }
    }

}
