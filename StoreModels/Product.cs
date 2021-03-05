using System;

namespace StoreModels
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        public override string ToString() => $"Product Details: \n\t Name: {this.Name} \n\t Product id: {this.Id} \n\t Price: ${this.Price}";

    }
}