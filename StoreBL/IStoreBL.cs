using StoreModels;
using System.Collections.Generic;

namespace StoreBL
{
    public interface IStoreBL
    {
//CustomerBL***************************************************************
        List<Customer> GetCustomer();
        void AddCustomer(Customer newCustomer);
        Customer GetCustomerByName(string name);
//LocationBL***************************************************************
        List<Location> GetLocations();
//OrderBL******************************************************************
        void AddOrder(Order newOrder);
        List<Order> GetOrders();
        List<Order> GetOrdersByLocation(string locationName);
        Order GetOrdersByCustomerId(int customerId);
        List<Inventory> GetInventories();

//ProductBL******************************************************************
        List<Product> GetProducts();
        Product GetProductById(int Id);
        OrderItem AddItemToOrder(OrderItem newItem);

        List<OrderItem> GetItems();

        void AddItem(OrderItem newItem);
    }
}