using SADVO.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Domain.Interfaces
{
    public interface IPartidoPoliticoRepository : IGenericRepository<PartidoPolitico>
    {
        Task<bool> ExistsAsync(int partidoPoliticoId);
    }
}
