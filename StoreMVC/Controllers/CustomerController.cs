using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreMVC.Models;
using StoreBL;
using Microsoft.AspNetCore.Http;
using StoreModels;
using System.Text.Json;

namespace StoreMVC.Controllers
{
    public class CustomerController : Controller
    {
        private IStoreBL _storeBL;
        private IMapper _mapper;
        private Customer _customer;
        private Location _location;
        public CustomerController(IStoreBL storeBL, IMapper mapper)
        {
            _storeBL = storeBL;
            _mapper = mapper;
        }
        // GET: CustomerController
       public ActionResult Index()
        {
            return View(_storeBL.GetCustomers().Select(customer => _mapper.cast2CustomerIndexVM(customer)).ToList());
        }

       /*public ActionResult Index(string search)
        {
            if (search != null)
            {
                List<Customer> custList = _storeBL.GetCustomers().Select(customer => (customer)).ToList();
                foreach (var item in custList)
                {
                    if (item.Name.ToString() == search)
                    {
                        List<CustomerIndexVM> list = new List<CustomerIndexVM>();
                        list.Add(_mapper.cast2CustomerIndexVM(item));
                        return View(list);
                    }
                }
            }
            return View(_storeBL.GetCustomers().Select(customer => _mapper.cast2CustomerIndexVM(customer)).ToList());
        }*/

        // GET: CustomerController/Details/5
        public ActionResult Details(string name)
        {
            return View(_mapper.cast2CustomerCRVM(_storeBL.GetCustomerByName(name)));
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCRVM newCustomer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _storeBL.AddCustomer(_mapper.cast2Customer(newCustomer));
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(string name)
        {
            return View(_mapper.cast2CustomerEditVM(_storeBL.GetCustomerByName(name)));
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult CustomerLoggedIn()
        {
            /*ViewBag.Message = HttpContext.Session.GetString("customerName");*/
            return View();
        }

        public ActionResult Login(string CName)
        {
            if (CName.Equals("Manager"))
            {
                return View("ManagerPage");
            }

            List<Customer> custList = _storeBL.GetCustomers().Select(customer => (customer)).ToList();
            foreach (var item in custList)
            {
                

                if (item.Name.ToString() == CName)
                {
                    /*_customer = item;*/
                    _customer = _storeBL.GetCustomerByName(CName);
                    _customer.OrderHistory = _storeBL.GetCustomerOrderHistory(CName);
                    HttpContext.Session.SetString("customerData", JsonSerializer.Serialize(_customer));
                    //HttpContext.Session.SetString("customerName", CName);
                    return View("CustomerLoggedIn");
                }
            }       
                return View("Create");
        }

        [HttpPost]
        public ActionResult StartShopping(string store)
        {
            _location = _storeBL.GetLocations().FirstOrDefault(l => l.Id == int.Parse(store));
            _location.Inventory = _storeBL.GetInventories().Where(i => i.LocationId == _location.Id).ToList();
            HttpContext.Session.SetString("storeSelection", JsonSerializer.Serialize(_location));

            return View();
        }

        public ActionResult AddToCart(string quantity, string cartProduct)
        {
            _customer = JsonSerializer.Deserialize<Customer>(HttpContext.Session.GetString("customerData"));
            _location = JsonSerializer.Deserialize<Location>(HttpContext.Session.GetString("storeSelection"));

            int cp = int.Parse(cartProduct);

            Product product = _storeBL.GetProductById(cp);

            /*_storeBL.AddToCart(selectedInventory, _customer, quantity);*/

            _storeBL.AddToCart(product, quantity, _customer, _location);
            /*_storeBL.RemoveInventory(selectedInventory, quantity);*/

            return View("ProductView");
        }

        public ActionResult Cart()
        {
            _customer = JsonSerializer.Deserialize<Customer>(HttpContext.Session.GetString("customerData"));
            List<Cart> inv = _storeBL.GetCarts().Where(c => c.CustomerId == _customer.Id).ToList();

            foreach (Cart c in inv)
            {
                c.Product = _storeBL.GetProductById(c.ProductId);
            }
            return View(inv);
        }

        public ActionResult Checkout(int tp)
        {
            //grab variables
            _customer = JsonSerializer.Deserialize<Customer>(HttpContext.Session.GetString("customerData"));
            _location = JsonSerializer.Deserialize<Location>(HttpContext.Session.GetString("storeSelection"));
            List<Cart> carts = _storeBL.GetCarts().Where(c => c.CustomerId == _customer.Id).ToList();
            int orderID = _storeBL.GetOrders().LastOrDefault().Id + 1;
            Cart cart = carts.Last();

            //Add Order to table
            Order newOrder = new Order()
            {
                CustomerId = _customer.Id,
                LocationId = _location.Id,
                Date = DateTime.Now,
                Price = tp
            };
            _storeBL.AddOrder(newOrder);

            //loop
            foreach (Cart c in carts)
            {
                //add Items to table
                OrderItem itm = new OrderItem()
                {
                    OrderId = orderID,
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                };
                _storeBL.AddOrderItem(itm);

                //reduce stock in appropriate store
                Inventory oldInv = _storeBL.GetInventories()
                    .FirstOrDefault(i => i.ProductId == c.ProductId && i.LocationId == _location.Id);
                _storeBL.SubtractFromInventory(oldInv, c.Quantity);
            }

            //Empty Cart
            _storeBL.RemoveCart(_storeBL.GetCarts()
                .Where(c => c.ProductId == cart.ProductId && c.LocationId == cart.LocationId).ToList());

            return View("CustomerLoggedIn");
        }
        public ActionResult StoreSelector()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProductView(string store)
        {
            _location = _storeBL.GetLocations().FirstOrDefault(l => l.Id == int.Parse(store));
            _location.Inventory = _storeBL.GetInventories().Where(i => i.LocationId == _location.Id).ToList();
            HttpContext.Session.SetString("storeSelection", JsonSerializer.Serialize(_location));

            return View();
        }

        public ActionResult CustomerOrderHistory()
        {
            _customer = JsonSerializer.Deserialize<Customer>(HttpContext.Session.GetString("customerData"));
            List<Order> orders = _storeBL.GetOrders().Where(o => o.CustomerId == _customer.Id).ToList();
            List<OrderItem> items = _storeBL.GetOrderItems();
            foreach (OrderItem i in items)
            {
                i.Product = _storeBL.GetProductById(i.ProductId);
            }
            HttpContext.Session.SetString("orderItems", JsonSerializer.Serialize(items));

            return View(orders);

        }

        public ActionResult LocationOrderHistory()
        {
            _location = JsonSerializer.Deserialize<Location>(HttpContext.Session.GetString("locationData"));
            List<Order> orders = _storeBL.GetOrders().Where(o => o.LocationId == _location.Id).ToList();
            List<OrderItem> items = _storeBL.GetOrderItems();
            foreach (OrderItem i in items)
            {
                i.Product = _storeBL.GetProductById(i.ProductId);
            }
            HttpContext.Session.SetString("orderItems", JsonSerializer.Serialize(items));

            return View(orders);

        }

    }
}
    
