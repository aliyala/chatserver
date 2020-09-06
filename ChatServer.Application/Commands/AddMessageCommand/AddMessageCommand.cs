using ChatServer.Application.Repositories;
using ChatServer.Application.ResultTypes;
using ChatServer.Domain;
using System;
using System.Threading.Tasks;

namespace ChatServer.Application.Commands.CreateMessageCommand
{
    internal class AddMessageCommand : ICommand<(string content, string author), MessageResult>
    {
        private readonly IMessageWriteOnlyRepository _messageRepository;

        public AddMessageCommand(IMessageWriteOnlyRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<MessageResult> Execute((string content, string author) arg)
        {
            var newMessage = await _messageRepository.Add(new Message
            {
                Content = arg.content,
                Author = arg.author,
                CreatedDate = DateTime.UtcNow
            });

            return new MessageResult {
                Author = newMessage.Author,
                Content = newMessage.Content,
                CreatedDate = newMessage.CreatedDate
            };
        }
    }
}
