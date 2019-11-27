using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoBankBackend.Common.Exceptions
{
    public class ExceptionBase : Exception
    {
        #region ----- Attributes ------------------------------------------------------

        private int _code;
        private string _description;

        #endregion

        #region ----- Properties ------------------------------------------------------

        public int Code
        {
            get => _code;
        }
        public string Description
        {
            get => _description;
        }

        #endregion

        #region ----- Constructor -----------------------------------------------------

        public ExceptionBase(string message, string description, int code) : base(message)
        {
            _code = code;
            _description = description;
        }

        #endregion
    }
}
