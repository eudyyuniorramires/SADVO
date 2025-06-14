using SADVO.Core.Application.Dtos.PartidoPolitico;
using SADVO.Core.Application.Dtos.Usuario;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Services
{
    public class PartidoPoliticoService : IPartidoPoliticoService
    {
        public Task<bool> AddAsync(PartidoPoliticoDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PartidoPoliticoDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<PartidoPoliticoDto>> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public Task<PartidoPoliticoDto?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(PartidoPoliticoDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
