using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class CustomerCRVM
    {
        [DisplayName("Customer Name")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Phone Number")]
        [Required]
        public string Phone { get; set; }
    }
}
