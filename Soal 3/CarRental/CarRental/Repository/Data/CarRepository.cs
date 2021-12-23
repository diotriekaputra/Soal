using CarRental.Context;
using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Repository.Data
{
    public class CarRepository : GeneralRepository<MyContext, Car, string>
    {
        public CarRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
