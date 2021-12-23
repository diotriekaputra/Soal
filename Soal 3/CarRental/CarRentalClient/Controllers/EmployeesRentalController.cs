using CarRental.Models;
using CarRental.ViewModel;
using LeaveClient.Base.Controllers;
using LeaveClient.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalClient.Controllers
{
    public class EmployeesRentalController : BaseController<Employee, EmployeeRentalRepository, string>
    {
        private readonly EmployeeRentalRepository repository;
        public EmployeesRentalController(EmployeeRentalRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Auth(LoginVM login)
        {
            var jwtToken = await repository.Auth(login);
            var token = jwtToken.Token;
            var pesan = jwtToken.Messages;
            var empId = jwtToken.NIK;

            if (token == "" || token == null)
            {
                if (pesan == "0")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            HttpContext.Session.SetString("JWToken", token);
            return RedirectToAction("Index", "Auth");
        }
    }
}
