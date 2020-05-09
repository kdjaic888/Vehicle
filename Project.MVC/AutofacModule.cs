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
            builder.Register(c => new VehicleMake(c.Resolve<ILogger<VehicleMake>>()))
                .As<IVehicleMake>()
                .InstancePerLifetimeScope();

            builder.Register(c => new VehicleModel(c.Resolve<ILogger<VehicleModel>>()))
               .As<IVehicleModel>()
               .InstancePerLifetimeScope();
        }
    }
}