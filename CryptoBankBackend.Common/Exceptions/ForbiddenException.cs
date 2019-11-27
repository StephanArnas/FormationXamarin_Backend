using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CryptoBankBackend.Common.Exceptions
{
    public class ForbiddenException : ExceptionBase
    {
        public ForbiddenException(string message) : base(message, string.Empty, (int)HttpStatusCode.Forbidden) { }
        public ForbiddenException(string message, string description) : base(message, description, (int)HttpStatusCode.Forbidden) { }
    }
}
