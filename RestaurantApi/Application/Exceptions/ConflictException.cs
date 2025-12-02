using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ConflictException : Exception
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.Conflict;
        public ConflictException(string message) : base(message)  {}
    }
}