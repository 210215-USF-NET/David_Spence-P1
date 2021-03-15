using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreModels;

namespace StoreDL
{
    public class StoreRepoDB : IStoreRepository
    {
        private readonly StoreDBContext _context;
        public StoreRepoDB(StoreDBContext context)
        {
            _context = context;
        }
        //CUSTOMER*******************************************************CUSTOMER
        public Customer AddCustomer(Customer newCustomer)
        {
            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
            return newCustomer;
        }
        public List<Customer> GetCustomers() 
        {
            return _context.Customers
                .AsNoTracking()
                .Select(customer => customer)
                .ToList();
        }
        public Customer GetCustomerByName(string name) 
        {
            return _context.Customers
                .AsNoTracking()
                .FirstOrDefault(customer => customer.Name == name);
        }
        //LOCATION********************************************************LOCATION
        public List<Location> GetLocations()
        {
            return _context.Locations
                .AsNoTracking()
                .Select(location => location)
                .ToList();
        }
        //ORDER***********************************************************ORDER
        public Order AddOrder(Order newOrder)
        {
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return newOrder;
        }
        public List<Order> GetOrders()
        {
            return _context.Orders
                .AsNoTracking()
                .Select(order => order)
                .ToList();
        }
        public List<Order> GetCustomerOrderHistory(int CustId)
        {
            return _context.Orders
                .AsNoTracking()
                .Select(order => order)
                .ToList();
        }
        public List<Order> GetCustomerOrderHistory(string CustName)
        {
            return _context.Orders
                .AsNoTracking()
                .Select(order => order)
                .ToList();
        }
        public List<Order> GetLocationOrderHistory(int locationId)
        {
            return _context.Orders
                .AsNoTracking()
                .Select(order => order)
                .ToList();
        }
        //INVENTORY********************************************************INVENTORY
        public List<Inventory> GetInventories()
        {
            return _context.Inventories
                .AsNoTracking()
                .Select(inventory => inventory)
                .ToList();
        }
        public void UpdateInventory(Inventory inv) { }

        public Inventory AddToCart(Inventory inv, Customer customer, int quantity)
        {
            _context.Carts.Add(new Cart
            {
                CustomerId = customer.Id,
                LocationId = inv.LocationId,
                ProductId = inv.ProductId,
                Quantity = quantity
            });

            _context.SaveChanges();

            return inv;
        }
        //PRODUCT***********************************************************PRODUCT
        public List<Product> GetProducts()
        {
            return _context.Products
                .AsNoTracking()
                .Select(product => product)
                .ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products
                .AsNoTracking()
                .FirstOrDefault(product => product.Id == id);
        }
        //CART***************************************************************CART
        public Cart AddCart(Cart newCart)
        {
            _context.Carts.Add(newCart);
            _context.SaveChanges();
            return newCart;
        }
        public List<Cart> GetCarts()
        {
            return _context.Carts
                .AsNoTracking()
                .Select(cart => cart)
                .ToList();
        }
        //ORDERITEM***********************************************************ORDERITEM
        public OrderItem AddOrderItem(OrderItem newOrderItem)
        {
            _context.OrderItems.Add(newOrderItem);
            _context.SaveChanges();
            return newOrderItem;
        }
        public List<OrderItem> GetOrderItems()
        {
            return _context.OrderItems
                .AsNoTracking()
                .Select(orderItem => orderItem)
                .ToList();
        }

        
    }
}
