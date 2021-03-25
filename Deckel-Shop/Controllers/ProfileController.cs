﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deckel_Shop.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View("views/profile/Customer/index.cshtml");
        }


        public IActionResult Customer()
        {
            return View("views/profile/Customer/index.cshtml");
        }
        
        public IActionResult Administrator()
        {
            return View("/views/profile/administrator/index.cshtml");
        }

        public IActionResult Admin_customerList()
        {
            return View("/views/profile/administrator/Admin_customerList.cshtml");
        }

        public IActionResult Admin_customerOrderHistory()
        {
            return View("/views/profile/administrator/Admin_customerOrderHistory.cshtml");
        }
    }
}
