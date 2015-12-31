﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Cross.BLL;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Cross.WebHost.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork work = new UnitOfWork();

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Account = "duanyumei";
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
