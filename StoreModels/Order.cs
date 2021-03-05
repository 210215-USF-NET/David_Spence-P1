using System;
using System.Collections.Generic;

namespace StoreModels
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public DateTime Date { get; set; }


        public override string ToString() => $"Order Details: \n\t Order #: {this.Id}";

    }
}