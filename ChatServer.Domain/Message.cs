using System;

namespace ChatServer.Domain
{
    public class Message : IEntity
    {
        public Guid Id { get; private set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Author { get; set; }
    }
}
