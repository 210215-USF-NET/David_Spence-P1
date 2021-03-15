using System;
using System.Collections.Generic;
using Serilog;

namespace StoreModels
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<Order> OrderHistory { get; set; }
        private void ThrowNullException()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/Logs.json").CreateLogger();
            Log.Error("Null value of OrderItem.");

            throw new Exception("Value is Null");
        }

        public override string ToString() => $"Customer Details: \n\t Name: {this.Name} \n\t Phone: {this.Phone} \n\t Id #: {this.Id}";

    }
}