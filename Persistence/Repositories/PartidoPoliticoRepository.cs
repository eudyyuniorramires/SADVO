using Microsoft.EntityFrameworkCore;
using SADVO.Core.Domain.Entities;
using SADVO.Core.Domain.Interfaces;
using SADVO.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Infrastructure.Persistence.Repositories
{
    public class PartidoPoliticoRepository : GenericRepository<PartidoPolitico>, IPartidoPoliticoRepository
    {
        private readonly ApplicationDbContext _context;

        public PartidoPoliticoRepository(ApplicationDbContext context) : base(context) 
        {

            _context = context;


        }

     
        public async Task<List<PartidoPolitico>> GetActivosAsync()
        {
            return await _context.PartidoPoliticos
                .Where(p => p.EstaActivo)
                .ToListAsync();
        }
    }   }
