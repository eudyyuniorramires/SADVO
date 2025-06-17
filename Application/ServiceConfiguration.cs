using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application
{
    public static class ServiceConfiguration
    {
        //Extension de metodos DECORATOR PATTERN 
        public static void AddAplicationLayerIOC(this IServiceCollection service)
        {

     
            #region Services IOC
            service.AddTransient<IPuestoElectivo, PuestoElectivoService>();
            service.AddTransient<ICiudadanoService, CiudadanoService>();
            service.AddTransient<IPartidoPoliticoService, PartidoPoliticoService>();
            service.AddTransient<IUsuarioService, UsuarioService>();
            service.AddTransient<IDirigentePartidoService, DirigentePartidoService>();
            #endregion

        }


    }
}
