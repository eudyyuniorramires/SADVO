using SADVO.Core.Application.Dtos.Candidato;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Domain.Entities;
using SADVO.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SADVO.Core.Application.Services
{
    public class CandidatoService : ICandidatosService
    {

        private readonly ICandidatoRepository _candidatosRepository;

        private readonly IAsignacionDirigentePoliticoRepository _asignacionDirigentePoliticoRepository;

        private readonly IDirigentePartidoService _dirigentePartidoService;

        public CandidatoService(ICandidatoRepository candidatoRepository,IAsignacionDirigentePoliticoRepository asignacionDirigentePoliticoRepository, IDirigentePartidoService dirigentePartidoService)
        {
            _candidatosRepository = candidatoRepository;
            _asignacionDirigentePoliticoRepository = asignacionDirigentePoliticoRepository;
            _dirigentePartidoService = dirigentePartidoService;
        }

        public async Task<bool> AddAsync(CandidatoDto dto, int usuarioId)
        {
            try
            {
                var asignacion = await _asignacionDirigentePoliticoRepository.GetByUsuarioIdAsync(usuarioId);
                if (asignacion == null || asignacion.PartidoPolitico == null)
                    return false;

                dto.PartidoPoliticoId = asignacion.PartidoPoliticoId;

                Candidato entity = new()
                {
                    Id = dto.Id,
                    Apellido = dto.Apellido,
                    Nombre = dto.Nombre,
                    EstaActivo = dto.EstaActivo,
                    PartidoPoliticoId = dto.PartidoPoliticoId,
                    FotoPath = dto.FotoPath
                };

                Candidato? returnEntity = await _candidatosRepository.AddAsync(entity);

                return returnEntity != null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el candidato", ex);
            }
        }


        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
            
                await _candidatosRepository.DeleteAsync(id);
                return true;

            } 
            catch (Exception) 
            { 
            
                throw new Exception("Error al eliminar el candidato");

            }
        }

        public async Task<List<CandidatoDto>> GetAllList()
        {
            try 
            {
            
              var listaEntities = await _candidatosRepository.GetAllList();

                var listaEntitesDto = listaEntities.Select(s => new CandidatoDto()
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Apellido = s.Apellido,
                    FotoPath = s.FotoPath,
                    EstaActivo = s.EstaActivo,
                    PartidoPoliticoId = s.PartidoPoliticoId
                }).ToList();

                return listaEntitesDto;
            }

            catch (Exception) 
            {
                return [];
            
            }
        }


        public async Task<CandidatoDto?> GetById(int id)
        {
            try 
            {
            
                var entity = await _candidatosRepository.GetById(id);

                if (entity == null) 
                {
                    return null;
                }

                return new CandidatoDto()
                {
                    Id = entity.Id,
                    Apellido = entity.Apellido,
                    FotoPath = entity.FotoPath,
                    Nombre = entity.Nombre,


                };
            }
            catch (Exception) 
            {

                throw new Exception("Error al obtener el candidato por id");

            }
        }

        public async Task<bool> UpdateAsync(CandidatoDto dto)
        {
            try 
            {

                Candidato entity = new()
                {
                    Id = dto.Id,
                    Apellido = dto.Apellido,
                    FotoPath = dto.FotoPath,
                    Nombre = dto.Nombre,
                    

                };

                Candidato ?returnEntity = await _candidatosRepository.UpdateAsync(dto.Id, entity);

                if(returnEntity == null)
                {
                    return false;
                }

                return true;

            } 
            catch (Exception) 
            { 
            
            throw new Exception ("Error al actualizar el candidato");
            }
        }



        public async Task<string?> GetNombrePartidoDeDirigenteAsync(int usuarioId)
        {
            var asignacion = await _dirigentePartidoService.GetByUsuarioIdAsync(usuarioId);

            if (asignacion == null || asignacion.PartidoPolitico == null)
                return null;

            return asignacion.PartidoPolitico.Nombre;
        }

        public async Task<List<CandidatoDto>> GetAllWithIncludeAsync(int usuarioId)
        {
            // Paso 1: Obtener el partido político asociado al usuario (dirigente)
            var asignacion = await _dirigentePartidoService.GetByUsuarioIdAsync(usuarioId);

            if (asignacion == null || asignacion.PartidoPolitico == null)
                return new List<CandidatoDto>();

            int partidoId = asignacion.PartidoPoliticoId;

            // Paso 2: Obtener todos los candidatos (con Include) y filtrar por el partido
            var entities = await _candidatosRepository.GetAllWithInclude();

            var listaFiltrada = entities
                .Where(x => x.PartidoPoliticoId == partidoId)
                .Select(x => new CandidatoDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    EstaActivo = x.EstaActivo,
                    FotoPath = x.FotoPath,
                    PartidoPoliticoId = x.PartidoPoliticoId,
                    NombrePartido = x.PartidoPolitico?.Nombre
                })
                .ToList();

            return listaFiltrada;
        }


        public async Task<List<CandidatoDto>> GetAllByDirigenteAsync(int usuarioId)
        {
            var asignacion = await _asignacionDirigentePoliticoRepository.GetByUsuarioIdAsync(usuarioId);

            if (asignacion == null || asignacion.PartidoPolitico == null)
                return new List<CandidatoDto>();

            int partidoId = asignacion.PartidoPoliticoId;

            var entities = await _candidatosRepository.GetAllWithInclude();

            var listaFiltrada = entities
                .Where(x => x.PartidoPoliticoId == partidoId)
                .Select(x => new CandidatoDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    EstaActivo = x.EstaActivo,
                    FotoPath = x.FotoPath,
                    PartidoPoliticoId = x.PartidoPoliticoId,
                    NombrePartido = x.PartidoPolitico?.Nombre
                })
                .ToList();

            return listaFiltrada;
        }

        public Task<List<CandidatoDto>> GetAllWithIncludeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
