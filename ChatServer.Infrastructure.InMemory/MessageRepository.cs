using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatServer.Application.Repositories;
using ChatServer.Domain;

namespace ChatServer.Infrastructure.InMemory
{
    public class MessageRepository : IMessageReadOnlyRepository, IMessageWriteOnlyRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

        public Task<Message> Add(Message message)
        {
            _context.Messages.Add(message);
            return Task.FromResult(message);
        }

        public Task<List<Message>> GetAll()
        {
            return Task.FromResult(_context.Messages.ToList());
        }
    }
}
