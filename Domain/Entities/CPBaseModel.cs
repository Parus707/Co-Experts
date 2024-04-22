using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CPBaseModel
    {
        public bool active { get; set; } = true;

        [Column(TypeName = "datetime2")]

        public DateTime created_date { get; set; } = DateTime.UtcNow;

        [StringLength(255)]
        public string created_by { get; set; }

        [Column(TypeName = "datetime2")]

        public DateTime? modified_date { get; set; }

        [StringLength(255)]
        public string? modified_by { get; set; }
    }
}
