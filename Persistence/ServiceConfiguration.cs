using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using SADVO.Core.Domain.Interfaces;
using SADVO.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Infrastructure.Persistence
{
    public static class ServiceConfiguration
    {
        //Extension de metodos DECORATOR PATTERN 
        public static void AddPersistenceLayerIOC(this IServiceCollection service) 
        {
            #region Repositories IOC


            service.AddTransient<IPuestoElectivoRepository, PuestoElectivoRepository>();    



            #endregion

        }


    }
}
