using System;
using Serilog;

namespace StoreModels
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        private void ThrowNullException()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/Logs.json").CreateLogger();
            Log.Error("Null value of OrderItem.");

            throw new Exception("Value is Null");
        }

        public override string ToString() => $"Product Details: \n\t Name: {this.Name} \n\t Product id: {this.Id} \n\t Price: ${this.Price}";

    }
}