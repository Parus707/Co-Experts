using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : CPBaseModel
    {
        [Key]
        public Guid CategoryId { get; set; } 

        public required string CategoryName { get; set; }
    }
}
