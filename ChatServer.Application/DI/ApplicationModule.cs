using Autofac;
using ChatServer.Application.Commands.CreateMessageCommand;
using ChatServer.Application.Queries.GetMessages;
using ChatServer.Application.Repositories;
using ChatServer.Application.ResultTypes;
using System.Collections.Generic;

namespace ChatServer.Application.DI
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new GetMessagesQuery(c.Resolve<IMessageReadOnlyRepository>()))
                .As<IQuery<List<MessageResult>>>().InstancePerLifetimeScope();

            builder.Register(c => new AddMessageCommand(c.Resolve<IMessageWriteOnlyRepository>()))
                .As<ICommand<(string content, string author), MessageResult>>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
