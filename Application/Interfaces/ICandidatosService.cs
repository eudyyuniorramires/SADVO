using SADVO.Core.Application.Dtos.Candidato;
using SADVO.Core.Application.Dtos.Ciudadano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Interfaces
{
    public interface ICandidatosService 
    {
        Task<bool> AddAsync(CandidatoDto dto, int UsuarioId);
        Task<bool> UpdateAsync(CandidatoDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<CandidatoDto>> GetAllList();
        Task<CandidatoDto?> GetById(int id);
        Task<string?> GetNombrePartidoDeDirigenteAsync(int usuarioId);

        Task<List<CandidatoDto>> GetAllByDirigenteAsync(int usuarioId);


    }
}
