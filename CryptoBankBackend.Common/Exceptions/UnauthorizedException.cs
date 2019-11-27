using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CryptoBankBackend.Common.Exceptions
{
    public class UnauthorizedException : ExceptionBase
    {
        public UnauthorizedException(string message) : base(message, string.Empty, (int)HttpStatusCode.BadRequest) { }
        public UnauthorizedException(string message, string description) : base(message, description, (int)HttpStatusCode.BadRequest) { }
    }
}
