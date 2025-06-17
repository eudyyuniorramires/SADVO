using Microsoft.EntityFrameworkCore;
using SADVO.Core.Application.Dtos.DirigentePolitico;
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
using System.Xml;

namespace SADVO.Core.Application.Services
{
    public class DirigentePartidoService : IDirigentePartidoService
    {

        private readonly IAsignacionDirigentePoliticoRepository _asignacionDirigentePoliticoRepository; 
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IPartidoPoliticoService _partidoSevice;
        private readonly IPartidoPoliticoRepository _partidoRepository;


        public DirigentePartidoService(
          IAsignacionDirigentePoliticoRepository asignacionDirigentePoliticoRepository,
          IUsuarioRepository usuarioRepository,
          IPartidoPoliticoRepository partidoRepository,
          IUsuarioService usuarioService,
            IPartidoPoliticoService partidoPoliticoService)
        {
            _asignacionDirigentePoliticoRepository = asignacionDirigentePoliticoRepository;
            _usuarioRepository = usuarioRepository;
            _partidoRepository = partidoRepository;
            _usuarioService = usuarioService;
            _partidoSevice = partidoPoliticoService;
        }

        private async Task CargarCombos()
        {
            var usuarios = await _usuarioService.GetAll(); // solo dirigentes activos
            var partidos = await _partidoSevice.GetAll(); // solo partidos activos

        }

        public async Task<bool> AddAsync(DirigentePartidoDto dto)
        {
            try
            {
                if (dto.UsuarioId <= 0 || dto.PartidoPoliticoId <= 0)
                    throw new Exception("Todos los campos son obligatorios.");

                var usuario = await _usuarioRepository.GetById(dto.UsuarioId);
                if (usuario == null || !usuario.EstaActivo)
                    throw new Exception("El dirigente seleccionado no existe o no está activo.");

                if (usuario.Rol != RolUsuario.Dirigente)
                    throw new Exception("El usuario seleccionado no tiene el rol de dirigente político.");


                var yaAsignado = await _asignacionDirigentePoliticoRepository.ExistsByUsuarioId(dto.UsuarioId);
                if (yaAsignado)
                    throw new Exception("Este dirigente ya está relacionado con otro partido político.");

                var partido = await _partidoRepository.GetById(dto.PartidoPoliticoId);
                if (partido == null || !partido.EstaActivo)
                    throw new Exception("El partido político seleccionado no existe o no está activo.");

                var entity = new DirigentePartido
                {
                    UsuarioId = dto.UsuarioId,
                    PartidoPoliticoId = dto.PartidoPoliticoId
                };

                var result = await _asignacionDirigentePoliticoRepository.AddAsync(entity);
                return result != null;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public async Task<bool> DeleteAsync(int id)
        {
            try 
            {
            
                await _asignacionDirigentePoliticoRepository.DeleteAsync(id);
                return true;


            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el dirigente del partido político", ex);
            }
        }

        

        public async Task<List<DirigentePartidoDto>> GetAll()
        {
            var relaciones = await _asignacionDirigentePoliticoRepository.GetAllWithIncludesAsync();

            return relaciones.Select(x => new DirigentePartidoDto
            {
                Id = x.Id,
                UsuarioId = x.UsuarioId,
                PartidoPoliticoId = x.PartidoPoliticoId,
                Usuario = x.Usuario != null ? new UsuarioDto
                {
                    Id = x.Id,
                    Nombre = x.Usuario.Nombre,
                    Apellido = x.Usuario.Apellido,
                } : null,
                PartidoPolitico = x.PartidoPolitico != null ? new PartidoPoliticoDto
                {
                    Id = x.PartidoPolitico.Id,
                    Siglas = x.PartidoPolitico.Siglas,
                    Nombre = x.PartidoPolitico.Nombre
                    

                } : null
            }).ToList();

        }


        public async Task<DirigentePartidoDto?> GetById(int id)
        {
            try
            {
                var entity = await _asignacionDirigentePoliticoRepository.GetById(id);

                if (entity == null)
                {
                    return null;
                }

                return new DirigentePartidoDto
                {
                    Id = entity.Id,
                    UsuarioId = entity.UsuarioId,
                    PartidoPoliticoId = entity.PartidoPoliticoId

                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el Dirigente patido con ID: " + id, ex);
            }
        }

        public async Task<bool> UpdateAsync(DirigentePartidoDto dto)
        {
            try
            {

                DirigentePartido entity = new() { Id = dto.Id,UsuarioId = dto.UsuarioId, PartidoPoliticoId = dto.PartidoPoliticoId };
                DirigentePartido? returnEntity = await _asignacionDirigentePoliticoRepository.UpdateAsync(dto.Id, entity);

                if (returnEntity == null)
                {

                    return false;
                    
                }

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Error al actualizar el Dirigente Partido con ID: " + dto.Id);
            }
        }

        public async Task<bool> ExistsByUsuarioId(int usuarioId)
        {
            return await _asignacionDirigentePoliticoRepository.ExistsByUsuarioId(usuarioId);
        }

        public Task<List<DirigentePartidoDto>> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }
    }
}
