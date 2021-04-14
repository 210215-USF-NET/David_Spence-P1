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
        List<Order> GetCustomerOrderHistory(string custName);
        List<Order> GetLocationOrderHistory(int locationId);
        //INVENTORY*********************************************************INVENTORY
        List<Inventory> GetInventories();
        Inventory UpdateInventory(Inventory inv);
        Inventory AddToCart(Inventory inv, Customer customer, string quantity);
        Inventory SubtractFromInventory(Inventory selectedInventory, int quantity);
        Inventory AddInventory(Inventory newInv);
        //PRODUCT***********************************************************PRODUCT
        List<Product> GetProducts();
        Product GetProductById(int id);
        Product GetProductById(string name);
        //CART**************************************************************CART
        Cart AddCart(Cart newCart);
        List<Cart> GetCarts();
        List<Cart> RemoveCart(List<Cart> cart);
        Product AddToCart(Product product, string quantity, Customer customer, Location location);
        //OrderItem********************************************************ORDERITEM
        OrderItem AddOrderItem(OrderItem newOrderItem);
        List<OrderItem> GetOrderItems();
    }
}
