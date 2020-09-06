using ChatServer.Application;
using ChatServer.Application.ResultTypes;
using HotChocolate;
using HotChocolate.Subscriptions;
using System;
using System.Threading.Tasks;

namespace ChatServer.Graphql
{
    public class Mutation
    {
        private readonly ICommand<(string content, string author), MessageResult> _addCommand;

        public Mutation(ICommand<(string content, string author), MessageResult> addCommand)
        {
            _addCommand = addCommand ?? throw new ArgumentNullException(nameof(addCommand));
        }
        
        public async Task<MessageResult> CreateMessage(string content, string author, [Service]IEventSender eventSender)
        {
            var newMessage = await _addCommand.Execute((content, author));
            await eventSender.SendAsync(new OnAddMessage(newMessage));
            return newMessage;
        }
    }
}
