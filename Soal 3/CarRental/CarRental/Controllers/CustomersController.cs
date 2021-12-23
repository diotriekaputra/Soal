using CarRental.Base;
using CarRental.Context;
using CarRental.Models;
using CarRental.Repository.Data;
using CarRental.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController<Customer, CustomerRepository, string>
    {
        private readonly CustomerRepository customerRepository;
        private readonly MyContext myContext;
        public IConfiguration _configuration;
        public CustomersController(CustomerRepository customerRepository, IConfiguration configuration, MyContext myContext) : base(customerRepository)
        {
            this.customerRepository = customerRepository;
            this.myContext = myContext;
            this._configuration = configuration;
        }
        [Route("AddCustomer")]
        [HttpPost]
        public ActionResult AddCustomer(AddCustomerVM registerUserVM)
        {
            var check = customerRepository.AddCustomer(registerUserVM);
            if (check == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, message = "Data Ditambahkan" });
            }
            if (check == 2)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data Gagal Ditambahkan. Email sudah Terdaftar" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data Gagal Ditambahkan. Phone Number Sudah Terdaftar" });

            }
        }
        [HttpGet("GetIdProfile/{CustomerId}")]
        public ActionResult GetIdProfile(string CustomerId)
        {

            var result = customerRepository.GetIdProfile(CustomerId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = "Data Dengan Email Tersebut Tidak Ditemukan" });

        }

        [Route("GetCustomers")]
        [HttpGet]
        public ActionResult<RentVM> GetRentStatus()
        {
            var result = customerRepository.GetRentStatus();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = " Data tidak ada data di tabel" });

        }

    }
}
