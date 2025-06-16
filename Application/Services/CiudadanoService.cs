using Microsoft.Identity.Client;
using SADVO.Core.Application.Dtos.Ciudadano;
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
    public class CiudadanoService : ICiudadanoService
    {
        private readonly ICiudadanoRepository _ciudadanoRepository;

        public CiudadanoService(ICiudadanoRepository ciudadanoRepository)
        {

            _ciudadanoRepository = ciudadanoRepository;

        }


        //Agregar
        public async Task<bool> AddAsync(CiudadanoDto dto)
        {
            try
            {
                var existingEntity = await _ciudadanoRepository.GetByConditionalAsync(c => c.DocumentoIdentidad == dto.DocumentoIdentidad);
                if (existingEntity != null)
                {
                    return false;
                }

                Ciudadano entity = new()
                {
                    Id = 0,
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Email = dto.Email,
                    DocumentoIdentidad = dto.DocumentoIdentidad,
                    EstaActivo = dto.EstaActivo
                };

                var returnEntity = await _ciudadanoRepository.AddAsync(entity);

                return returnEntity != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar un ciudadano: {ex.Message}", ex);
            }
        }


        public async Task<bool> DeleteAsync(int id)
        {
            try
            {

                await _ciudadanoRepository.DeleteAsync(id);
                return true;

            }
            catch
            (Exception)
            {

                return false;
            }
        }

        

        public async Task<List<CiudadanoDto>> GetAll()
        {

            try
            {

                var listaEntities = await _ciudadanoRepository.GetAllList();

                var listaEntitiesDto = listaEntities.Select(s => new CiudadanoDto()
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Apellido = s.Apellido,
                    Email = s.Email,
                    DocumentoIdentidad = s.DocumentoIdentidad,
                    EstaActivo = s.EstaActivo

                }).ToList();

                return listaEntitiesDto;

            }
            catch (Exception)
            {

                return [];
            }

        }

        public Task<List<CiudadanoDto>> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public async Task<CiudadanoDto> GetById(int Id)
        {
            try
            {

                var entity = await _ciudadanoRepository.GetById(Id);

                if (entity == null)
                {
                    return null;
                }

                CiudadanoDto dto = new() { Id = entity.Id, Nombre = entity.Nombre, Apellido = entity.Apellido, Email = entity.Email, DocumentoIdentidad = entity.DocumentoIdentidad, EstaActivo = entity.EstaActivo };

                return dto;

            }
            catch (Exception ex)
            {

                throw new Exception("Hubo un error en obtener un Ciudadano revisele mijo " + ex);
            }
        }


        public async Task<bool> UpdateAsync(CiudadanoDto dto)
        {
            try
            {
                var existingEntity = await _ciudadanoRepository.GetByConditionalAsync(c => c.DocumentoIdentidad == dto.DocumentoIdentidad);
                if (existingEntity != null)
                {
                    return false;
                }

                Ciudadano entity = new() { Id = dto.Id, Nombre = dto.Nombre, Apellido = dto.Apellido, Email = dto.Email, DocumentoIdentidad = dto.DocumentoIdentidad, EstaActivo = dto.EstaActivo };

                Ciudadano? returnEntity = await _ciudadanoRepository.UpdateAsync(dto.Id, entity);

                if (returnEntity == null)
                {

                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Hubo un error en actualizar un Ciudadano revisele mijo " + ex);
            }

        }
    }
}
