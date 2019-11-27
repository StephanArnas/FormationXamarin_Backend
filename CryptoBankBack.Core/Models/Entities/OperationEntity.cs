using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CryptoBankBackend.Core.Models.Entities
{
    [Table("Operation")]
    public class OperationEntity : EntityBase
    {
        #region ----- PROPERTIES ------------------------------------------------------

        [Required]
        public string Name { get; set; }

        [Required]
        public string TransactionNumber { get; set; }

        [Required]
        public string RecipientEmail { get; set; }

        [Required]
        public double Amount { get; set; }

        #endregion

        #region ----- FOREIGN KEYS ----------------------------------------------------

        public int UserId { get; set; }

        public virtual UserEntity User { get; set; }

        #endregion



        public OperationEntity Clone()
        {
            return (OperationEntity)this.MemberwiseClone();
        }
    }
}
