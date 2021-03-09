using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreMVC.Models;
using StoreBL;


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
        // GET: CustomerController
        public ActionResult Index()
        {
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
            return View("CreateCustomer");
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
    }
        // POST: CustomerController/Edit/5
        /*[HttpPost]
        [ValidateAntiForgeryToken]*/
        /*public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: CustomerController/Delete/5
        /* public ActionResult Delete(int id)
         {
             return View();
         }

         // POST: CustomerController/Delete/5
         [HttpPost]
         [ValidateAntiForgeryToken]*/
        /*public ActionResult Delete(int id, IFormCollection collection)
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
    
