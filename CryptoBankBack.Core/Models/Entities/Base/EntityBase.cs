using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CryptoBankBackend.Core.Models.Entities
{
    public class EntityBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;

        [DataType(DataType.DateTime)]
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
