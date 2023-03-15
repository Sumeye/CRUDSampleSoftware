using Autofac;
using CrudSample.Core.Repositories;
using CrudSample.Core.Services;
using CrudSample.Core.UnitOfWork;
using CrudSample.Repository;
using CrudSample.Repository.Repositories;
using CrudSample.Repository.UnitOfWork;
using CrudSample.Service.Mapping;
using CrudSample.Service.Services;
using System.Reflection;
using Module = Autofac.Module;
namespace CrudSample.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>))
           .As(typeof(IGenericRepository<>))
           .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Service<>))
                   .As(typeof(IService<>))
                   .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly=Assembly.GetExecutingAssembly();
            var repoAssembly=Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
