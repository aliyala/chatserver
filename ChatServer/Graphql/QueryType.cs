using HotChocolate.Types;

namespace ChatServer.Graphql
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(t => t.GetMessages()).Type<ListType<MessageType>>();
        }
    }
}
