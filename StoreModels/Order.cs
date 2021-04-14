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
        public int Price { get; set; }
        public Customer Customer { get; set; }
        public Location Location { get; set; }
        public void AddProductPriceToTotal(Product product)
        {
            this.Price += product.Price;
        }

        public override string ToString() => $"Order Details: \n\t Order #: {this.Id}";

    }
}