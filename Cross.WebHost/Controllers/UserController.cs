using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Cross.WebHost.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Images()
        {
            return View();
        }

        public IActionResult Videos()
        {
            return View();
        }

        public IActionResult Question()
        {
            return View();
        }

    }
}
