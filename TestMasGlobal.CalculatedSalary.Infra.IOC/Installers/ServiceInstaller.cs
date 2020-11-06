using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using TestMasGlobal.CalculatedSalary.Domain.Interfaces.Base;
using TestMasGlobal.CalculatedSalary.Domain.Services.Base;

namespace TestMasGlobal.CalculatedSalary.Infra.IOC.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            container.Register(
                Classes.FromAssemblyContaining(typeof(BaseService<>))
                    .BasedOn(typeof(IBaseService<>))
                    .LifestyleTransient()
                    .WithService.AllInterfaces());
        }
    }
}
