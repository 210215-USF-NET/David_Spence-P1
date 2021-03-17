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
        public List<Order> GetOrdersByLocation(string name)
        {
            throw new NotImplementedException();
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
            Customer customer = _context.Customers
                .AsNoTracking()
                .FirstOrDefault(customer => customer.Name == CustName);

            return _context.Orders
                .AsNoTracking()
                .Where(order => order.CustomerId == customer.Id)
                .ToList();
        }
        public List<Order> GetLocationOrderHistory(int locationId)
        {
            Location location = _context.Locations
                .AsNoTracking()
                .FirstOrDefault(location => location.Id == locationId);

            return _context.Orders
                .AsNoTracking()
                .Where(order => order.LocationId == location.Id)
                .ToList();
        }
        //INVENTORY********************************************************INVENTORY
        public List<Inventory> GetInventories()
        {
            List<Inventory> invs = _context.Inventories
                .AsNoTracking()
                .Select(inv => inv)
                .ToList();

            foreach (Inventory i in invs)
            {
                i.Product = GetProductById(i.ProductId);
            }

            return invs;
        }
        public Inventory UpdateInventory(Inventory inv)
        {
            try
            {
                Inventory oldInv = _context.Inventories
                    .FirstOrDefault(i => i.Id == inv.Id);

                _context.Entry(oldInv).CurrentValues.SetValues(inv);

                _context.SaveChanges();
                _context.ChangeTracker.Clear();

                return inv;
            }
            catch (Exception)
            {
                //Log.Error("That product is not in stock at the selected location!");
                AddInventory(inv);
                return inv;
            }
        }
        public Inventory AddInventory(Inventory newInv)
        {
            _context.Inventories.Add(newInv);
            _context.SaveChanges();
            return newInv;
        }
        public Inventory SubtractFromInventory(Inventory selectedInventory, int quantity)
        {
            Inventory newInv = selectedInventory;

            newInv.Quantity -= quantity;
            UpdateInventory(newInv);

            return selectedInventory;
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

        public Product GetProductById(string name)
        {
            return _context.Products
                .AsNoTracking()
                .FirstOrDefault(product => product.Name == name);
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
        public List<Cart> RemoveCart(List<Cart> cart)
        {
            _context.Carts.RemoveRange(cart);
            _context.SaveChanges();

            return cart;
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
        public Inventory AddToCart(Inventory selectedInventory, Customer cust, string quantity)
        {
            _context.Carts.Add(new Cart
            {
                CustomerId = cust.Id,
                LocationId = selectedInventory.LocationId,
                ProductId = selectedInventory.ProductId,
                Quantity = int.Parse(quantity)
            });

            _context.SaveChanges();

            return selectedInventory;
        }

        public Product AddToCart(Product product, string quantity, Customer customer, Location location)
        {
            _context.Carts.Add(new Cart
            {
                CustomerId = customer.Id,
                LocationId = location.Id,
                ProductId = product.Id,
                Quantity = int.Parse(quantity)
            });

            _context.SaveChanges();

            return product;
        }
    }
        
}
