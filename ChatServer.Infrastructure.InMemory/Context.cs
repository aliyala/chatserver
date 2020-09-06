using ChatServer.Domain;
using System.Collections.Concurrent;

namespace ChatServer.Infrastructure.InMemory
{
    public class Context
    {
        public ConcurrentBag<Message> Messages { get; set; }

        public Context()
        {
            Messages = new ConcurrentBag<Message>();
        }
    }
}
