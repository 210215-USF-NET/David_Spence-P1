using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{
    public interface IStoreRepository
    {
//CUSTOMER***********************************************************
        Customer AddCustomer(Customer newCustomer);
        List<Customer> GetCustomer();
        Customer GetCustomerByName(string name);
        List<Order> GetCustomerOrderHistory(string name);
//LOCATION***********************************************************
        List<Location> GetLocations();
//ORDER***********************************************************
        void AddOrder(Order newOrder);
        List<Order> GetOrders();
        //List<Order> GetOrdersByCustomer(int CustomerId);
        Order GetOrdersByCustomerId(int CustomerId);
        List<Order> GetOrdersByLocation(string locationName);    

        List<Inventory> GetInventories();    
//PRODUCT***********************************************************
        List<Product> GetProducts(); 
        Product GetProductById(int Id);
        OrderItem AddItemToOrder(OrderItem newItem);

        List<OrderItem> GetItems();
        void AddItem(OrderItem newItem);
    }
}