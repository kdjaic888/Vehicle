using Autofac.Core;
using Autofac;
using Microsoft.Extensions.Logging;
using Project.Service;
using Project.Interface;
using Project.Service.Model;
using Project.Interface.Interface;

namespace Project.MVC
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method. All of this starts
            // with the services.AddAutofac() that happens in Program and registers Autofac
            // as the service provider.
            builder.Register(c => new VehicleMake(c.Resolve<ILogger<VehicleMake>>()))
                .As<IVehicleMake>()
                .InstancePerLifetimeScope();

            builder.Register(c => new VehicleModel(c.Resolve<ILogger<VehicleModel>>()))
               .As<IVehicleModel>()
               .InstancePerLifetimeScope();
        }
    }
}