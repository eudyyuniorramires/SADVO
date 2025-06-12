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
    public class PuestoElectivoRepository: GenericRepository<PuestoElectivo>, IPuestoElectivoRepository
    {
        public PuestoElectivoRepository(ApplicationDbContext context) : base(context) { }
    }
}
