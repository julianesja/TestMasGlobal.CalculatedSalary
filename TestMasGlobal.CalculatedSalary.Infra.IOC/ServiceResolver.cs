using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using TestMasGlobal.CalculatedSalary.Infra.IOC.Installers;

namespace TestMasGlobal.CalculatedSalary.Infra.IOC
{
    public class ServiceResolver
    {
       
        private static WindsorContainer contenedor;

       
        private static IServiceProvider serviceProvider;

      
        public ServiceResolver(IServiceCollection services)
        {
            contenedor = new WindsorContainer();

            contenedor.Install(
                new RepositoryInstaller(),
                new ServiceInstaller(),
                new ApplicationInstaller()

               );

            serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(contenedor, services);
        }

    
        public IServiceProvider GetServiceProvider()
        {
            return serviceProvider;
        }
    }
}
