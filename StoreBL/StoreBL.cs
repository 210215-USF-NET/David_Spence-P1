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
//CustomerBL***************************************************************   
        public void AddCustomer(Customer newCustomer)
        {
            _repo.AddCustomer(newCustomer);
        }
        public List<Customer> GetCustomer()
        {
            return _repo.GetCustomer();
        }
        public Customer GetCustomerByName(string name)
        {
            //Todo: check if the name given is not null or empty string 
            return _repo.GetCustomerByName(name);
        }
//LocationBL***************************************************************
        public List<Location> GetLocations()
        {
            return _repo.GetLocations();
        }
//OrderBL******************************************************************
        public void AddOrder(Order newOrder)
        {
             _repo.AddOrder(newOrder);
        }
        public List<Order> GetOrders()
        {
            return _repo.GetOrders();
        }
        public Order GetOrdersByCustomerId(int customerId)
        {
            return _repo.GetOrdersByCustomerId(customerId);
        }
        public List<Order> GetOrdersByLocation(string locationName)
        {
            return _repo.GetOrdersByLocation(locationName);
        }
        public List<Inventory> GetInventories()
        {
            return _repo.GetInventories();
        }
//ProductBL******************************************************************
        public List<Product> GetProducts()
        {
            return _repo.GetProducts();
        }
        public Product GetProductById(int Id)
        {
            return _repo.GetProductById(Id);
        }
        public OrderItem AddItemToOrder(OrderItem newItem)
        {
            return _repo.AddItemToOrder(newItem);
        }
        public List<OrderItem> GetItems()
        {
            return _repo.GetItems();
        }
        public void AddItem(OrderItem newItem)
        {
             _repo.AddItem(newItem);
        }
    }
}