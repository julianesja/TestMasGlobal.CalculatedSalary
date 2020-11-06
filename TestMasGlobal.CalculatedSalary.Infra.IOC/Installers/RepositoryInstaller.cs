using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using TestMasGlobal.CalculatedSalary.Domain.Interfaces.Base;
using TestMasGlobal.CalculatedSalary.Infra.Data.Base;
using TestMasGlobal.CalculatedSalary.Infra.Data.DataContextDatabases;

namespace TestMasGlobal.CalculatedSalary.Infra.IOC.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
          
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            container.Register(
                Classes.FromAssemblyContaining(typeof(BaseRepository<>))
                    .BasedOn(typeof(IBaseRepository<>))
                    .LifestyleTransient()
                    .WithService.AllInterfaces());

            container.Register(Component.For(typeof(IConexionApi<>)).ImplementedBy(typeof(ConexionApi<>)).LifeStyle.Transient);

        }
    }
}
