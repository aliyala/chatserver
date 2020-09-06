using System.Threading.Tasks;

namespace ChatServer.Application
{
    public interface IQuery<ResultType>
    {

        Task<ResultType> Execute();
    }
}
