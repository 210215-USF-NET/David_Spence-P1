using System;
using Serilog;

namespace StoreModels
{
    public class OrderItem
    {
        //This goes with Inventory
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        private void ThrowNullException()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/Logs.json").CreateLogger();
            Log.Error("Null value of OrderItem.");

            throw new Exception("Value is Null");
        }
    }
}