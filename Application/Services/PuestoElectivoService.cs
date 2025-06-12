using SADVO.Core.Application.Dtos.PuestoElectivo;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Domain.Entities;
using SADVO.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Services
{
    public class PuestoElectivoService : IPuestoElectivo
    {

        private readonly IPuestoElectivoRepository _puestoElectivoRepository;

        public PuestoElectivoService(IPuestoElectivoRepository puestoElectivoRepository)
        {
            _puestoElectivoRepository = puestoElectivoRepository;


        }


        //Agregar pa un pueto eletivo pp aiuda 
        public async Task<bool> AddAsync(PuestoElectivoDto dto)
        {
            try 
            {

                PuestoElectivo entity = new ()
                {

                    Id = 0,
                    Nombre = dto.Nombre,
                    Descripcion = dto.Descripcion,

                };

                PuestoElectivo? returnEntity = await _puestoElectivoRepository.AddAsync(entity);
                if (returnEntity == null) 
                {
                    return false;
                }

                return true;

            }
            catch(Exception ex)
            {
                throw new Exception("Puse un H..... en agregar dejame ve ", ex);
            }
        }

        //Eliminar 

        public async Task<bool> DeleteAsync(int id)
        {
            try
            { 
                await _puestoElectivoRepository.DeleteAsync(id);
                return true;

            }
            catch(Exception)
            {
               return false;

            }
        }

        //Obtener todos los puestos electivos

        public async Task<List<PuestoElectivoDto>> GetAll()
        {

            try 
            {

                var listaEntities = await _puestoElectivoRepository.GetAllList();

                var listaEntitiesDto = listaEntities.Select(s => new PuestoElectivoDto()
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Descripcion = s.Descripcion,
                    EstaActivo = s.EstaActivo
                }).ToList();

                return listaEntitiesDto;

            }
            catch(Exception )
            {
                return [];
            }
            
        }
        


        public Task<List<PuestoElectivoDto>> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }


        //Obtener por Id 
        public async Task<PuestoElectivoDto?> GetById(int id)
        {
            try 
            {
            
              var entity = await _puestoElectivoRepository.GetById(id);
                if (entity == null) 
                {
                    return null;
                }
                PuestoElectivoDto dto = new()
                { Id = entity.Id,Nombre = entity.Nombre ,Descripcion = entity.Descripcion, EstaActivo = entity.EstaActivo };
                return dto;

            }
            catch (Exception ex)
            {
                throw new Exception("Puse un H..... en obtener por id dejame ve ", ex);
            }
        }

        //Actualizar 
        public async Task<bool> UpdateAsync(PuestoElectivoDto dto)
        {
            try 
            {
            
                PuestoElectivo entity = new()
                {
                    Id = dto.Id,Nombre = dto.Nombre,
                    Descripcion = dto.Descripcion,
                    EstaActivo = dto.EstaActivo
                };

                PuestoElectivo? returnEntity =  await _puestoElectivoRepository.UpdateAsync(dto.Id, entity);

                if(returnEntity == null)
                {
                    return false;
                }

                return true;
            }
            catch
            (Exception ex)
            {
                throw new Exception("Puse un H..... en actualizar dejame ve ", ex);
            }
        }
    }
}
