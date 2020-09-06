using ChatServer.Application.ResultTypes;
using HotChocolate.Subscriptions;

namespace ChatServer.Graphql
{
    public class OnAddMessage : EventMessage
    {
        public OnAddMessage(MessageResult message)
            : base("onAddMessage", message)
        {
        }
    }    
}
