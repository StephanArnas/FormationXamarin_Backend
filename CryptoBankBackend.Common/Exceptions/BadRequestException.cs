using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CryptoBankBackend.Common.Exceptions
{
    public class BadRequestException : ExceptionBase
    {
        public BadRequestException(string message) : base(message, string.Empty, (int)HttpStatusCode.BadRequest) { }
        public BadRequestException(string message, string description) : base(message, description, (int)HttpStatusCode.BadRequest) { }
    }
}
