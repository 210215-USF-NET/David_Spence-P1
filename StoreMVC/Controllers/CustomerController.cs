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

namespace StoreMVC.Controllers
{
    public class CustomerController : Controller
    {
        private IStoreBL _storeBL;
        private IMapper _mapper;
        public CustomerController(IStoreBL storeBL, IMapper mapper)
        {
            _storeBL = storeBL;
            _mapper = mapper;
        }
/*        // GET: CustomerController
        public ActionResult Index()
        {
            return View(_storeBL.GetCustomers().Select(customer => _mapper.cast2CustomerIndexVM(customer)).ToList());
        }*/

        public ActionResult Index(string search)
        {
            if (search != null)
            {
                List<Customer> custList = _storeBL.GetCustomers().Select(cust => (cust)).ToList();
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
            return View(_storeBL.GetCustomers().Select(cust => _mapper.cast2CustomerIndexVM(cust)).ToList());
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

        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(CustomerCRVM customerVM)
        {
            if (ModelState.IsValid)
            {
                Customer customer = _storeBL.GetCustomerByName(customerVM.Name);
                if (customer == null)
                {
                    return NotFound();
                }
                HttpContext.Session.SetString("Name", customer.Name);
                HttpContext.Session.SetInt32("Id", customer.Id);
                return Redirect("/");
            }
            return BadRequest("Invalid model state");
        }

        // GET: CustomerController/Delete/5
        /*public ActionResult Delete(string name)
        {
            _storeBL.DeleteCustomer(_storeBL.GetCustomerByName(name));
            return RedirectToAction(nameof(Index));
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

    }
}
    
