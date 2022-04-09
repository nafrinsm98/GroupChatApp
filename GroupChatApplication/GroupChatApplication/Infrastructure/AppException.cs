using System;

namespace GroupChatApplication.Api.Infrastructure
{
    public class AppException : Exception
    {
        public AppException() : base() { }

        public AppException(string message) : base(message) { }
    }
}
