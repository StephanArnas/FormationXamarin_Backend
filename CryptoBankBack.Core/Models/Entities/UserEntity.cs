using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CryptoBankBackend.Core.Models.Entities
{
    [Table("User")]
    public class UserEntity : EntityBase
    {
        #region ----- PROPERTIES ------------------------------------------------------

        [Required, StringLength(50), DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required, StringLength(50), DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required, StringLength(100), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, StringLength(50), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public double Credits { get; set; } = 0;

        #endregion

        #region ----- FOREIGH KEY -----------------------------------------------------

        public virtual ICollection<OperationEntity> Operations { get; set; }

        #endregion
    }
}
