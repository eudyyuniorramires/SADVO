using SADVO.Core.Application.Dtos.PartidoPolitico;
using SADVO.Core.Application.Dtos.Usuario;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Domain.Entities;
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

        private readonly IPartidoPoliticoRepository _partidoPoliticoRepository;


        public PartidoPoliticoService(IPartidoPoliticoRepository partidoPoliticoRepository)
        {
            _partidoPoliticoRepository = partidoPoliticoRepository;
        }

        public  async Task<bool> AddAsync(PartidoPoliticoDto dto)
        {
            try 
            {


                PartidoPolitico entity = new() { Id = 0, Nombre = dto.Nombre, Descripcion = dto.Descripcion, Siglas = dto.Siglas, LogoPath = dto.LogoPath, EstaActivo = dto.EstaActivo };

                PartidoPolitico? returnEntity = await _partidoPoliticoRepository.AddAsync(entity);


                if (returnEntity == null) 
                {

                    return false;
                
                }

                return true;

            }
            catch (Exception ex)
            {
               throw new Exception("Error al agregar el partido político", ex);
            }
        }



        public async Task<bool> DeleteAsync(int id)
        {
            try 
            {


                await _partidoPoliticoRepository.DeleteAsync(id);
                return true;

            } 
            catch (Exception) 
            {
              
                throw new Exception("Error al eliminar el partido político con ID: " + id);

            }
        }

        public async Task<List<PartidoPoliticoDto>> GetAll()
        {
            try
            {

                var listaEntities = await _partidoPoliticoRepository.GetAllList();

                var listaEntitiesDto = listaEntities.Select(s => new PartidoPoliticoDto()
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Descripcion = s.Descripcion,
                    Siglas = s.Siglas,
                    LogoPath = s.LogoPath,
                    EstaActivo = s.EstaActivo
                }).ToList();

                return listaEntitiesDto;

            } 
            catch (Exception) 
            {

                return [];
            }
        }

        public Task<List<PartidoPoliticoDto>> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public async Task<PartidoPoliticoDto?> GetById(int id)
        {

            try
            {
                var entity = await _partidoPoliticoRepository.GetById(id);

                if (entity == null)
                {
                    return null;
                }

                return new PartidoPoliticoDto
                {
                    Id = entity.Id,
                    Nombre = entity.Nombre,
                    Descripcion = entity.Descripcion,
                    Siglas = entity.Siglas,
                    LogoPath = entity.LogoPath,
                    EstaActivo = entity.EstaActivo
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el partido político con ID: " + id, ex);
            }

        }

        public async Task<bool> UpdateAsync(PartidoPoliticoDto dto)
        {
            try 
            {

                PartidoPolitico entity = new() { Id = dto.Id,Nombre = dto.Nombre, Descripcion = dto.Descripcion, Siglas = dto.Siglas, LogoPath = dto.LogoPath, EstaActivo = dto.EstaActivo };
                PartidoPolitico? returnEntity =await  _partidoPoliticoRepository.UpdateAsync(dto.Id, entity);

                if (returnEntity == null) 
                {

                    return false;
                
                }

                return true;
            } 
            catch (Exception) 
            {
                throw new Exception("Error al actualizar el partido político con ID: " + dto.Id);
            }

        }


    }
}
