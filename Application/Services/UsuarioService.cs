using SADVO.Core.Application.Dtos.Usuario;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Domain.Entities;
using SADVO.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _userRepository;

        public UsuarioService(IUsuarioRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> AddAsync(GuardarUsuarioDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Rol) ||
                    !Enum.TryParse<RolUsuario>(dto.Rol, ignoreCase: true, out var rolEnum))
                {
                    dto.ErrorMessage = $"El rol '{dto.Rol}' no es válido.";
                    return false;
                }

                Usuario entity = new()
                {
                    Id = 0,
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Email = dto.Email,
                    ContrasenaHash = dto.ContrasenaHash,
                    EstaActivo = dto.EstaActivo,
                    Rol = rolEnum
                };

                Usuario? returnEntity = await _userRepository.AddAsync(entity);

                if (returnEntity == null)
                {
                    dto.ErrorMessage = "Error al agregar el usuario. Por favor, inténtelo de nuevo.";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                dto.ErrorMessage = $"Error al agregar el usuario: {ex.Message}";
                return false;
            }
        }


        public async Task<bool> DeleteAsync(int id)
        {
            try 
            {
            
                await _userRepository.DeleteAsync(id);
                return true;


            } 
            catch (Exception)
            {

                return false;
            
            }
        }

        public async Task<List<UsuarioDto>> GetAll()
        {
            try 
            {
            
                var listaEntities = await _userRepository.GetAllList();
                var listaEntitiesDto =  listaEntities.Select(s => new UsuarioDto()
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Apellido = s.Apellido,
                    Email = s.Email,
                    ContrasenaHash = s.ContrasenaHash,
                    EstaActivo = s.EstaActivo,
                    Rol = s.Rol.ToString()
                }).ToList();

                return listaEntitiesDto;



            } 
            catch (Exception) 
            {
                return [];
            }
        }

        public Task<List<UsuarioDto>> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioDto?> GetById(int id)
        {

            try
            {
                var entity = await _userRepository.GetById(id);

                if (entity == null)
                {
                    return null;
                }

                UsuarioDto dto = new()
                {
                    Id = entity.Id,
                    Nombre = entity.Nombre,
                    Apellido = entity.Apellido,
                    Email = entity.Email,
                    ContrasenaHash = entity.ContrasenaHash,
                    EstaActivo = entity.EstaActivo
                };
                return dto;
            }
            catch (Exception) 
            {

                return null;
            }
            
        }

        public async Task<bool> UpdateAsync(GuardarUsuarioDto dto)
        {
            try 
            {

                if (string.IsNullOrWhiteSpace(dto.Rol) ||
                   !Enum.TryParse<RolUsuario>(dto.Rol, ignoreCase: true, out var rolEnum))
                {
                    dto.ErrorMessage = $"El rol '{dto.Rol}' no es válido.";
                    return false;
                }
                Usuario entity = new()    
                {
                    Id = dto.Id,
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Email = dto.Email,
                    ContrasenaHash = dto.ContrasenaHash,
                    EstaActivo = dto.EstaActivo,
                    Rol = rolEnum


                };

                Usuario? returnEntiry = await _userRepository.UpdateAsync(dto.Id,entity);

                if (returnEntiry == null) 
                {

                    return false;
                
                    
                }

                return true;


            } catch (Exception) 
            {

                return false;
            
            }
        }
    }
}
