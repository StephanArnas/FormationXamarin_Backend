using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoBankBackend.Web.Models.Api
{
    public class OperationApi
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string TransactionNumber { get; set; }

        [Required]
        public string RecipientEmail { get; set; }

        [Required]
        public double Amount { get; set; }
    }
}
