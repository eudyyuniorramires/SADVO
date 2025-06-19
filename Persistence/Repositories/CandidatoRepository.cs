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
   public class CandidatoRepository : GenericRepository<Candidato>, ICandidatoRepository
    {
        public readonly ApplicationDbContext _context;
        public CandidatoRepository(ApplicationDbContext context) : base(context)
        {
        
            _context = context;


        }

        public async Task<List<Candidato>> GetAllWithInclude()
        {
            return await _context.Candidatos
                .Include(c => c.PartidoPolitico)
                .ToListAsync();
        }

       
    }
}
