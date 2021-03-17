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
        List<Order> GetOrdersByLocation(string name);
        //ORDER**************************************************************
        Order AddOrder(Order newOrder);
        List<Order> GetOrders();
        List<Order> GetCustomerOrderHistory(int CustId);
        List<Order> GetCustomerOrderHistory(string CustName);
        List<Order> GetLocationOrderHistory(int locationId);
        //INVENTORY*********************************************************
        List<Inventory> GetInventories();
        Inventory UpdateInventory(Inventory inv);
        Inventory AddToCart(Inventory inv, Customer customer, string quantity);
        Inventory SubtractFromInventory(Inventory selectedInventory, int quantity);
        Inventory AddInventory(Inventory newInv);
        //PRODUCT***********************************************************
        List<Product> GetProducts();
        Product GetProductById(int Id);
        Product GetProductById(string name);
        //CART************************************************************
        Cart AddCart(Cart newCart);
        List<Cart> GetCarts();
        List<Cart> RemoveCart(List<Cart> cart);
        Product AddToCart(Product product, string quantity, Customer customer, Location location);
        //OrderItem****************************************************
        OrderItem AddOrderItem(OrderItem newOrderItem);
        List<OrderItem> GetOrderItems();

    }
}