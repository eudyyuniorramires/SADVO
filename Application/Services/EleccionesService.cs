//using SADVO.Core.Application.Dtos.Elecciones;
//using SADVO.Core.Application.Dtos.Elecciones.SADVO.Core.Application.Dtos.Eleccion;
//using SADVO.Core.Application.Interfaces;
//using SADVO.Core.Domain.Entities;
//using SADVO.Core.Domain.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.Design;
//using System.Linq;
//using System.Threading.Tasks;

//namespace SADVO.Core.Application.Services
//{
//    public class EleccionService : IEleccionesService
//    {
//        private readonly IEleccionesRepository _eleccionRepository;
//        private readonly IPuestoElectivoRepository _puestoRepository;
//        private readonly IPartidoPoliticoRepository _partidoRepository;
//        private readonly ICandidatoRepository _candidatoRepository;

//        public EleccionService(
//            IEleccionesRepository eleccionRepository,
//            IPuestoElectivoRepository puestoRepository,
//            IPartidoPoliticoRepository partidoRepository,
//            ICandidatoRepository candidatoRepository)
//        {
//            _eleccionRepository = eleccionRepository;
//            _puestoRepository = puestoRepository;
//            _partidoRepository = partidoRepository;
//            _candidatoRepository = candidatoRepository;
//        }

//        public async Task<(bool PuedeCrear, List<string> Errores)> ValidarCreacionAsync()
//        {
//            var errores = new List<string>();

//            if (await _eleccionRepository.ExisteEleccionActivaAsync())
//                errores.Add("Ya existe una elección activa.");

//            var puestosActivos = (await _puestoRepository.GetAllList()).Where(p => p.Activo).ToList();
//            if (!puestosActivos.Any())
//                errores.Add("Debe haber al menos un puesto electivo activo.");

//            var partidosActivos = (await _partidoRepository.GetAllList()).Where(p => p.Activo).ToList();
//            if (partidosActivos.Count < 2)
//                errores.Add("Debe haber al menos dos partidos políticos activos.");

//            foreach (var partido in partidosActivos)
//            {
//                var sinCandidatos = new List<string>();

//                foreach (var puesto in puestosActivos)
//                {
//                    bool tieneCandidato = await _candidatoRepository.GetAllQuery()
//                        .AnyAsync(c => c.Activo && c.PartidoId == partido.Id && c.PuestoElectivoId == puesto.Id);

//                    if (!tieneCandidato)
//                        sinCandidatos.Add(puesto.Nombre);
//                }

//                if (sinCandidatos.Any())
//                    errores.Add($"El partido político {partido.Nombre} ({partido.Siglas}) no tiene candidatos para los puestos: {string.Join(", ", sinCandidatos)}.");
//            }

//            return (!errores.Any(), errores);
//        }

//        public async Task<bool> CrearAsync(CrearEleccionDto dto)
//        {
//            var eleccion = new Eleccion
//            {
//                Nombre = dto.Nombre,
//                Fecha = dto.Fecha,
//                Estado = EstadoEleccion.EnProceso,
//                Votos = new List<Voto>()
//            };

//            var resultado = await _eleccionRepository.AddAsync(eleccion);
//            return resultado != null;
//        }

//        public async Task<List<EleccionDto>> GetAllAsync()
//        {
//            var elecciones = await _eleccionRepository.GetAllListWithInclude(new List<string> { "Votos" });

//            return elecciones.OrderByDescending(e => e.Fecha)
//                .Select(e => new EleccionDto
//                {
//                    Id = e.Id,
//                    Nombre = e.Nombre,
//                    Fecha = e.Fecha,
//                    Estado = e.Estado,
//                    CantidadPartidos = e.Votos.Select(v => v.Candidato.PartidoId).Distinct().Count(),
//                    CantidadPuestos = e.Votos.Select(v => v.Candidato.PuestoElectivoId).Distinct().Count()
//                }).ToList();
//        }

//        public async Task<bool> FinalizarAsync(int id)
//        {
//            var eleccion = await _eleccionRepository.GetById(id);
//            if (eleccion == null || eleccion.Estado != EstadoEleccion.EnProceso)
//                return false;

//            eleccion.Estado = EstadoEleccion.Finalizada;
//            var actualizado = await _eleccionRepository.UpdateAsync(eleccion.Id, eleccion);
//            return actualizado != null;
//        }
//    }

//}