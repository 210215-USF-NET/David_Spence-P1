using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace StoreMVC.Models
{
    public class CustomerSearchVM
    {
        [Required]
        public string Name { get; set; }
    }
}