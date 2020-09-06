using ChatServer.Application;
using ChatServer.Application.ResultTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatServer.Graphql
{
    public class Query
    {
        private readonly IQuery<List<MessageResult>> _getMessagesQuery;

        public Query(IQuery<List<MessageResult>> getMessagesQuery)
        {
            _getMessagesQuery = getMessagesQuery ?? throw new ArgumentNullException(nameof(getMessagesQuery));
        }           

        public async Task<List<MessageResult>> GetMessages()
        {
            return await _getMessagesQuery.Execute();
        }
    }
}
