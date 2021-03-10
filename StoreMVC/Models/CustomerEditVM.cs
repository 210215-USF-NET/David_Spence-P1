using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class CustomerEditVM
    {
        [Required]
        [DisplayName("Customer Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }       
    }
}