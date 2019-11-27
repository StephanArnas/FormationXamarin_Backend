using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CryptoBankBackend.Common.Exceptions
{
    public class NotFoundException : ExceptionBase
    {
        public NotFoundException(string message) : base(message, string.Empty, (int)HttpStatusCode.NotFound) { }
        public NotFoundException(string message, string description) : base(message, description, (int)HttpStatusCode.NotFound) { }
    }
}
