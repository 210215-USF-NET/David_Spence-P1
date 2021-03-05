using System;

namespace StoreModels
{
    public class OrderItem
    {
        //This goes with Inventory
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public override string ToString() => $"Quantity: {this.Quantity}";

    }
}