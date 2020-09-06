using HotChocolate.Types;
namespace ChatServer.Graphql
{
    public class MutationType
        : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
        }
    }
}
