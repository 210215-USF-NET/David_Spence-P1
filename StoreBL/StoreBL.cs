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
        public List<Order> GetLocationOrderHistory(int locationId)
        {
            return _repo.GetLocationOrderHistory(locationId);
        }
        //INVENTORY*********************************************************INVENTORY
        public List<Inventory> GetInventories()
        {
            return _repo.GetInventories();
        }
        public void UpdateInventory(Inventory inv)
        {
            _repo.UpdateInventory(inv);
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
        //CART**************************************************************CART
        public Cart AddCart(Cart newCart)
        {
            return _repo.AddCart(newCart);
        }
        public List<Cart> GetCarts()
        {
            return _repo.GetCarts();
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
    }
}
