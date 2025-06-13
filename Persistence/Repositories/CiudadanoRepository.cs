using SADVO.Core.Application.Interfaces;
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
    public class CiudadanoRepository :GenericRepository<Ciudadano>, ICiudadanoRepository
    {
        public CiudadanoRepository(ApplicationDbContext context) : base(context) { }
    }
}
