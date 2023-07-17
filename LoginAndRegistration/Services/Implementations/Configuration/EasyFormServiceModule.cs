using Autofac;
using EasyForm.Services.Contracts;

namespace EasyForm.Services.Implementations.Configuration
{
    public class EasyFormServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationService>().As<IApplicationService>().InstancePerLifetimeScope();
            builder.RegisterType<UserApplicationService>().As<IUserApplicationService>().InstancePerLifetimeScope();
            builder.RegisterType<QuestionService>().As<IQuestionService>().InstancePerLifetimeScope();
            builder.RegisterType<PartService>().As<IPartService>().InstancePerLifetimeScope();
        }
    }
}