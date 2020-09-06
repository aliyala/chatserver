using ChatServer.Application.Repositories;
using ChatServer.Application.ResultTypes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatServer.Application.Queries.GetMessages
{
    internal class GetMessagesQuery : IQuery<List<MessageResult>>
    {
        private readonly IMessageReadOnlyRepository _messageRepository;

        internal GetMessagesQuery(IMessageReadOnlyRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<List<MessageResult>> Execute()
        {
            var messages = await _messageRepository.GetAll();
            return messages.Select(m => new MessageResult { 
                Author = m.Author,
                Content = m.Content,
                CreatedDate = m.CreatedDate
            }).ToList();
        }
    }
}
