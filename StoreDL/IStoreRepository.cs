using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{
    public interface IStoreRepository
    {
//CUSTOMER***********************************************************
        Customer AddCustomer(Customer newCustomer);
        List<Customer> GetCustomers();
        Customer GetCustomerByName(string name);
//LOCATION***********************************************************
        List<Location> GetLocations();
//ORDER************************************************************
        Order AddOrder(Order newOrder);
        List<Order> GetOrders();
        List<Order> GetCustomerOrderHistory(int CustId);
        List<Order> GetLocationOrderHistory(int locationId);
//INVENTORY*********************************************************
        List<Inventory> GetInventories();
        void UpdateInventory(Inventory inv);
//PRODUCT***********************************************************
        List<Product> GetProducts(); 
        Product GetProductById(int Id);
//CART************************************************************
        Cart AddCart(Cart newCart);
        List<Cart> GetCarts();
//OrderItem****************************************************
        OrderItem AddOrderItem(OrderItem newOrderItem);
        List<OrderItem> GetOrderItems();
    }
}
