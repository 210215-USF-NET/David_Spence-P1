using System;

namespace StoreModels
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public override string ToString() => $"Customer Details: \n\t Name: {this.Name} \n\t Phone: {this.Phone} \n\t Id #: {this.Id}";

    }
}