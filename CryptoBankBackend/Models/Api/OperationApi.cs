using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoBankBackend.Web.Models.Api
{
    public class OperationApi
    {
        public int Id { get; set; }

        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;

        public string Name { get; set; }

        public string TransactionNumber { get; set; }

        public string RecipientEmail { get; set; }

        public double Amount { get; set; }
    }
}
