using StoreModels;
using System.Collections.Generic;

namespace StoreBL
{
    public interface IStoreBL
    {
        //CUSTOMER*********************************************************CUSTOMER
        Customer AddCustomer(Customer newCustomer);
        List<Customer> GetCustomers();
        Customer GetCustomerByName(string name);
        //LOCATION*********************************************************LOCATION
        List<Location> GetLocations();
        //ORDER************************************************************ORDER
        Order AddOrder(Order newOrder);
        List<Order> GetOrders();
        List<Order> GetCustomerOrderHistory(int custId);
        List<Order> GetLocationOrderHistory(int locationId);
        //INVENTORY*********************************************************INVENTORY
        List<Inventory> GetInventories();
        void UpdateInventory(Inventory inv);
        //PRODUCT***********************************************************PRODUCT
        List<Product> GetProducts();
        Product GetProductById(int id);
        //CART**************************************************************CART
        Cart AddCart(Cart newCart);
        List<Cart> GetCarts();
        //OrderItem********************************************************ORDERITEM
        OrderItem AddOrderItem(OrderItem newOrderItem);
        List<OrderItem> GetOrderItems();
    }
}
