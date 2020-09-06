using ChatServer.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatServer.Application.Repositories
{
    public interface IMessageReadOnlyRepository
    {
        Task<List<Message>> GetAll();
    }
}
