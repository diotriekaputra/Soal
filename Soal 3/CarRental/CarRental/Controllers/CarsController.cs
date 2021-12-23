using CarRental.Models;
using CarRental.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Base.BaseController<Car, CarRepository, string>
    {
        public CarsController(CarRepository carRepository) : base(carRepository)
        {
        }
    }
}
