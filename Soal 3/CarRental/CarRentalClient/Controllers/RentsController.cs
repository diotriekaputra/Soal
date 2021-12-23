using CarRental.Models;
using CarRental.ViewModel;
using CarRentalClient.Repository.Data;
using LeaveClient.Base.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalClient.Controllers
{
    public class RentsController : BaseController<Rent, RentRepository, int>
    {
        private readonly RentRepository repository;
        public RentsController(RentRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public JsonResult AddRental(RentVM entity)
        {
            var result = repository.Post(entity);
            return Json(result);
        }
        public async Task<JsonResult> GetidRental(string id)
        {
            var result = await repository.GetRental(id);
            return Json(result);
        }
    }
}
