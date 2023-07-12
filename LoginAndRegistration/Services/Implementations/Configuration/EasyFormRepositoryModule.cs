using Autofac;
using EasyForm.Stores.Contracts;
using EasyForm.Stores.Implementations;

namespace EasyForm.Services.Implementations.Configuration
{
    public class EasyFormRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationStore>().As<IApplicationStore>().InstancePerLifetimeScope();
            builder.RegisterType<UserApplicationStore>().As<IUserApplicationStore>().InstancePerLifetimeScope();

        }
    }
}