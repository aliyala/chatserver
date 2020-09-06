using System;

namespace ChatServer.Domain
{
    internal interface IEntity
    {
        Guid Id { get; }
    }
}
