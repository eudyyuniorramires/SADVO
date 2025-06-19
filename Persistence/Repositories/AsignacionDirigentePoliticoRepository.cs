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
    public class AsignacionDirigentePoliticoRepository : GenericRepository<DirigentePartido>, IAsignacionDirigentePoliticoRepository
    {
        private readonly ApplicationDbContext _context;

        public AsignacionDirigentePoliticoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistsByUsuarioId(int usuarioId)
        {
            return await _context.DirigentePartidos.AnyAsync(x => x.UsuarioId == usuarioId);
        }

        public async Task<List<DirigentePartido>> GetAllWithIncludesAsync()
        {
            return await GetAllListWithInclude(new List<string> { "Usuario", "PartidoPolitico"});


        }

        public async Task<DirigentePartido?> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _context.DirigentePartidos
                .Include(dp => dp.PartidoPolitico) // ← incluir el Partido
                .FirstOrDefaultAsync(dp => dp.UsuarioId == usuarioId);
        }





    }

}
