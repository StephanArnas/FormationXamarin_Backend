using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoBankBackend.Core.Services
{
    public class ServiceBase
    {
        #region ----- ATTRIBUTES ------------------------------------------------------

        protected readonly IConfiguration _configuration = null;

        #endregion

        #region ----- CONSTRUCTOR -----------------------------------------------------

        public ServiceBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

    }
}
