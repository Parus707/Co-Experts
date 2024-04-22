using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{ 
    public class Vendor : CPBaseModel
    {
        [Key]
        public Guid VendorId { get; set; }  // Assuming you want an Id for each entry

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(15)]
        public string CNIC { get; set; }

        [MaxLength(50)]
        public string NTN { get; set; }

        [MaxLength(20)]
        public string PrimaryContact { get; set; }

        [MaxLength(100)]
        public string PrimaryEmail { get; set; }

        [MaxLength(20)]
        public string SecondaryContact { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }
    }
}
