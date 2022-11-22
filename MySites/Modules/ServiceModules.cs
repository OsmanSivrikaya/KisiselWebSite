//using MySites.Manager;
using Autofac;
using Core.Manager;
//using Core.Manager;
using Core.Repository.Concrete;
using MySites.Manager;
using Service.Services.Concrete;
using System.Reflection;
using Module = Autofac.Module;
namespace MySites.Modules
{
    public class ServiceModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var repoAssembly = Assembly.GetAssembly(typeof(GenericRepository<>));
            var servicesAssembly = Assembly.GetAssembly(typeof(GenericService<>));

            builder.RegisterAssemblyTypes(repoAssembly)
                  .Where(x => x.Name.EndsWith("Repository"))
                  .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(servicesAssembly)
                   .Where(x => x.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterType(typeof(ClaimsManager)).As(typeof(IClaimsManager)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(AccessManager)).As(typeof(IAccessManager)).InstancePerLifetimeScope();
        }
    }
}
