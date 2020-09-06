using System;

namespace ChatServer.Application.ResultTypes
{
    public class MessageResult
    {
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Author { get; set; }
    }
}
