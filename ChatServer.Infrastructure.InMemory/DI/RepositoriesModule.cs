using Autofac;
using ChatServer.Application.Repositories;

namespace ChatServer.Infrastructure.InMemory.DI
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new MessageRepository(new Context()))
                .As<IMessageReadOnlyRepository>()
                .As<IMessageWriteOnlyRepository>()
                .SingleInstance();

            base.Load(builder);
        }
    }
}
