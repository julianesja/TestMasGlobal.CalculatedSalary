using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using TestMasGlobal.CalculatedSalary.Aplications.Interfaces.Base;
using TestMasGlobal.CalculatedSalary.Aplications.Services.Base;

namespace TestMasGlobal.CalculatedSalary.Infra.IOC.Installers
{
    public class ApplicationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            container.Register(
                Classes.FromAssemblyContaining(typeof(AplicationService<>))
                    .BasedOn(typeof(IBaseAplication<>))
                    .LifestyleTransient()
                    .WithService.AllInterfaces());
        }
    }
}
