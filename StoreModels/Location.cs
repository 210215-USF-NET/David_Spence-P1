using System.Collections.Generic;


namespace StoreModels
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public List<Inventory> Inventory { get; set; }

        public override string ToString() => $"Location Details: \n\t Name: {this.Name} \n\t City: {this.City}";
    }
}