using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SADVO.Core.Domain.Interfaces;
using SADVO.Infrastructure.Persistence.Context;
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
        public static void AddPersistenceLayerIOC(this IServiceCollection service, IConfiguration config) 
        {

            #region
             var connectionString = config.GetConnectionString("DefaultConnection");
             service.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(connectionString,m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)),ServiceLifetime.Transient);

            #endregion
            #region Repositories IOC
            service.AddTransient<IPuestoElectivoRepository, PuestoElectivoRepository>();    
            #endregion

        }


    }
}
