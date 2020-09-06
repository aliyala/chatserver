using System.Threading.Tasks;

namespace ChatServer.Application
{
    public interface ICommand<ArgType, ResultType>
    {
        Task<ResultType> Execute(ArgType arg);
    }
}
