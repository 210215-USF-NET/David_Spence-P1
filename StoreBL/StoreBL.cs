using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;

namespace StoreBL
{
    public class StoreBL : IStoreBL
    {
        private IStoreRepository _repo;
        public StoreBL(IStoreRepository repo)
        {
            _repo = repo;
        }
        //CUSTOMER*********************************************************CUSTOMER
        public Customer AddCustomer(Customer newCustomer)
        {
            return _repo.AddCustomer(newCustomer);
        }
        public List<Customer> GetCustomers()
        {
            return _repo.GetCustomers();
        }
        public Customer GetCustomerByName(string name)
        {
            return _repo.GetCustomerByName(name);
        }
        //LOCATION*********************************************************LOCATION
        public List<Location> GetLocations()
        {
            return _repo.GetLocations();
        }
        //ORDER************************************************************ORDER
        public Order AddOrder(Order newOrder)
        {
            return _repo.AddOrder(newOrder);
        }
        public List<Order> GetOrders()
        {
            return _repo.GetOrders();
        }
        public List<Order> GetCustomerOrderHistory(int custId)
        {
            return _repo.GetCustomerOrderHistory(custId);
        }
        List<Order> GetCustomerOrderHistory(string custName)
        {
            return _repo.GetCustomerOrderHistory(custName);
        }
        public List<Order> GetLocationOrderHistory(int locationId)
        {
            return _repo.GetLocationOrderHistory(locationId);
        }
        //INVENTORY*********************************************************INVENTORY
        public List<Inventory> GetInventories()
        {
            return _repo.GetInventories();
        }
        public Inventory UpdateInventory(Inventory inv)
        {
            return _repo.UpdateInventory(inv);
        }
        public Inventory AddToCart(Inventory inv, Customer customer, string quantity)
        {
            return _repo.AddToCart(inv, customer, quantity);
        }
        public Inventory SubtractFromInventory(Inventory selectedInventory, int quantity)
        {
            return _repo.SubtractFromInventory(selectedInventory, quantity);
        }
        public Inventory AddInventory(Inventory newInv)
        {
            return _repo.AddInventory(newInv);
        }
        //PRODUCT***********************************************************PRODUCT
        public List<Product> GetProducts()
        {
            return _repo.GetProducts();
        }
        public Product GetProductById(int id)
        {
            return _repo.GetProductById(id);
        }
        public Product GetProductById(string name)
        {
            return _repo.GetProductById(name);
        }
        //CART**************************************************************CART
        public Cart AddCart(Cart newCart)
        {
            return _repo.AddCart(newCart);
        }
        public List<Cart> GetCarts()
        {
            return _repo.GetCarts();
        }
        public List<Cart> RemoveCart(List<Cart> cart)
        {
            return _repo.RemoveCart(cart);
        }
        //OrderItem********************************************************ORDERITEM
        public OrderItem AddOrderItem(OrderItem newOrderItem)
        {
            return _repo.AddOrderItem(newOrderItem);
        }
        public List<OrderItem> GetOrderItems()
        {
            return _repo.GetOrderItems();
        }

        List<Order> IStoreBL.GetCustomerOrderHistory(string custName)
        {
            return _repo.GetCustomerOrderHistory(custName);
        }

        public Product AddToCart(Product product, string quantity, Customer customer, Location location)
        {
            return _repo.AddToCart(product, quantity, customer, location);
        }

    }
}
