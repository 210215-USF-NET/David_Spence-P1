using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using StoreModels;


namespace StoreMVC.Models
{
    public class CustomerIndexVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
