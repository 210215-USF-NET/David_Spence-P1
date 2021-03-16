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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        public ActionResult Index(string search)
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
        }

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
            List<Customer> custList = _storeBL.GetCustomers().Select(customer => (customer)).ToList();
            foreach (var item in custList)
            {
                if (item.Name.ToString() == CName)
                {
                    _customer = item;
                    HttpContext.Session.SetString("customerData", JsonSerializer.Serialize(_customer));
                    HttpContext.Session.SetString("customerName", CName);
                    return View("CustomerLoggedIn");
                }
            }       
                return View("Create");
        }

        /*public ActionResult StoreSelect(string LName)
        {
            List<Location> locList = _storeBL.GetLocations().Select(location => (location)).ToList();
            foreach (var item in locList)
            {
                if (item.Name.ToString() == LName)
                {
                    _location = item;
                    HttpContext.Session.SetString("locationData", JsonSerializer.Serialize(_location));
                    HttpContext.Session.SetString("locationName", LName);
                    _location.Inventory = _storeBL.GetInventories().Where(inv => inv.LocationId == _location.Id).ToList();
                    return View("StartShopping");
                }
            }
            return View("CustomerLoggedIn");
        }*/

        /*public ActionResult StartShopping(string LName)
        {
            List<Location> locList = _storeBL.GetLocations().Select(location => (location)).ToList();
            foreach (var item in locList)
            {
                if (item.Name.ToString() == LName)
                {
                    _location = item;
                    HttpContext.Session.SetString("locationData", JsonSerializer.Serialize(_location));
                    HttpContext.Session.SetString("locationName", LName);
                    _location.Inventory = _storeBL.GetInventories().Where(inv => inv.LocationId == _location.Id).ToList();
                    return View();
                }
            }


            return View();
        }*/
        [HttpPost]
        public ActionResult StartShopping(string store)
        {
            _location = _storeBL.GetLocations().FirstOrDefault(l => l.Id == int.Parse(store));
            _location.Inventory = _storeBL.GetInventories().Where(i => i.LocationId == _location.Id).ToList();
            HttpContext.Session.SetString("storeSelection", JsonSerializer.Serialize(_location));

            return View();
        }

        public ActionResult AddToCart(int quantity, string cartProduct)
        {
            _customer = JsonSerializer.Deserialize<Customer>(HttpContext.Session.GetString("customerData"));
            _location = JsonSerializer.Deserialize<Location>(HttpContext.Session.GetString("storeSelection"));

            Inventory selectedInventory = _storeBL.GetInventories()
                .FirstOrDefault(p =>
                p.ProductId == int.Parse(cartProduct)
                && p.LocationId == _location.Id);

            _storeBL.AddToCart(selectedInventory, _customer, quantity);

            /*_storeBL.RemoveInventory(selectedInventory, quantity);*/

            return View("ProductView");
        }

    }
}
    
