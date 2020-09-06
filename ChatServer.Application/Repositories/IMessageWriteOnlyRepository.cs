using ChatServer.Domain;
using System.Threading.Tasks;

namespace ChatServer.Application.Repositories
{
    public interface IMessageWriteOnlyRepository
    {
        Task<Message> Add(Message message);
    }
}
