﻿using Database.Models;
using Deckel_Shop.Models;
using Deckel_Shop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deckel_Shop.Controllers
{
    public class ProfileController : Controller
    {
        private readonly CustomerService _cs;
        private readonly StockService _ss;
        public ProfileController()
        {
            _cs = new CustomerService();
            _ss = new StockService();
        }

        [Authorize]
        public IActionResult Index()
        {
            if (User.IsInRole("Administrator"))
            {
                return View("views/profile/administrator/index.cshtml");
            }
            Database.Models.DeckelShopContext ctx = new Database.Models.DeckelShopContext();


            return View("views/profile/Customer/index.cshtml", ctx.Customers);
        }
        public IActionResult CustomerOrderHistory()
        {
            return View("views/profile/Customer/OrderHistory.cshtml");
        }

        public IActionResult Customer()
        {
            return View("views/profile/Customer/index.cshtml");
        }
        [HttpPost]
        public IActionResult AddCustomer([FromForm] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _cs.AddCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        public IActionResult Administrator()
        {

            OrderService os = new OrderService();


            return View("/views/profile/administrator/index.cshtml", os.GetAllOrdersByOrderStatus("Not Delivered"));
        }

        public IActionResult Admin_customerList()
        {
            var listOfCustomers = _cs.GetAllCustomers();
            return View("/views/profile/administrator/Admin_customerList.cshtml", listOfCustomers);
        }

        public IActionResult Admin_customerOrderHistory()
        {
            return View("/views/profile/administrator/Admin_customerOrderHistory.cshtml");

        }


        public IActionResult Stock(int filter)
        {
            switch (filter)
            {
                case 1:
                    return View("views/profile/administrator/Stock.cshtml", _ss.GetAllAvailableProducts());
                case 2:
                    return View("views/profile/administrator/Stock.cshtml", _ss.GetAllRemovedProducts());
                default:
                    return View("views/profile/administrator/Stock.cshtml", _ss.GetAllProducts());
                 
            }
            
        }

        public IActionResult DeliveredOrders()
        {

            return View("views/profile/Administrator/DeliveredOrders.cshtml");
        }


        [HttpPost]
        public IActionResult AddProduct([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                _ss.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost]

        public IActionResult AddProductBackToStock(int id, int StockAmount)
        {
            _ss.AddBackToStock(id,StockAmount);
            return View("views/profile/administrator/Stock.cshtml", _ss.GetAllProducts());
        }
    

        [HttpPost]

        public IActionResult RemoveProduct(int id)
        {
            _ss.RemoveProduct(id);
            return View("views/profile/administrator/Stock.cshtml",_ss.GetAllProducts());
        }
    }
}
