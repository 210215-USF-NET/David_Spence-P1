using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using StoreModels;

namespace StoreMVC.Models
{
    public class OrderItemCRVM
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public Customer Customer { get; set; }
        public Location Location { get; set; }
    }
}
