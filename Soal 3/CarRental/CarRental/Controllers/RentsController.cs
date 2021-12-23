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
    public class RentsController : BaseController<Rent, RentRepository, int>
    {
        private readonly RentRepository rentRepository;
        private readonly MyContext myContext;
        public IConfiguration _configuration;
        public RentsController(RentRepository rentalRepository, IConfiguration configuration, MyContext myContext) : base(rentalRepository)
        {
            this.rentRepository = rentRepository;
            this.myContext = myContext;
            this._configuration = configuration;

        }
        [Route("AddRental")]
        [HttpPost]
        public ActionResult AddRental(RentVM rentVM)
        {
            var check = rentRepository.AddRental(rentVM);
            if (check == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, message = "Data berhasil ditambahkan" });
            }
            if (check == 2)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data gagal ditambahkan. Email sudah terdaftar" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data gagal ditambahkan. Phone sudah terdaftar" });

            }
        }
        [HttpGet("GetIdRental/{id}")]
        public ActionResult GetIdRental(int id)
        {

            var result = rentRepository.GetIdRent(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = "Data dengan Email tersebut tidak ditemukan" });

        }
    }
}
