using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalClient.Controllers
{
    public class AuthentificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Customer()
        {
            return View();
        }
        public IActionResult Rent()
        {
            return View();
        }
    }
}
