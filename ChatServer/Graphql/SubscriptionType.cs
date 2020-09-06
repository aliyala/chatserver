using ChatServer.Application.ResultTypes;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace ChatServer.Graphql
{

    public class Subscription
    {
        public object OnAddMessage(IEventMessage message)
        {
            return (MessageResult)message.Payload;
        }
    }

    public class SubscriptionType
    : ObjectType<Subscription>
    {
        protected override void Configure(IObjectTypeDescriptor<Subscription> descriptor)
        {
            descriptor.Field(t => t.OnAddMessage(default))
                .Type<NonNullType<MessageType>>();
        }
    }
}
