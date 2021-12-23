using CarRental.Context;
using CarRental.Models;
using CarRental.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Repository.Data
{
    public class RentRepository : GeneralRepository<MyContext, Rent, int>
    {
        private readonly MyContext myContext;
        public RentRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public int AddRental(RentVM rentVM)
        {
            Rent rent = new Rent();
            rent.CustomerId = rentVM.CustomerId;
            rent.CarId = rentVM.CarId;
            rent.RentDate = rentVM.RentDate;
            rent.ReturnDate = rentVM.ReturnDate;
            rent.Status = 0;

            History history = new History();
            history.RentDate = rentVM.RentDate;
            history.ReturnDate = rentVM.RentDate;
            history.OrderId = rent.OrderId;

            myContext.Rent.Add(rent);
            var result = myContext.SaveChanges();
            return result;
        }
        public IEnumerable<RentVM> GetIdRent(int id)
        {
            var getRent = (from r in myContext.Rent
                             join c in myContext.Customers on r.CustomerId equals c.CustomerId
                             join cr in myContext.Cars on r.CarId equals cr.CarId
                             select new RentVM
                             {
                                 OrderId = r.OrderId,
                                 EmployeeId = c.CustomerId,
                                 FirstName = c.FirstName,
                                 LastName = c.LastName,
                                 PhoneNumber = c.PhoneNumber,
                                 Email = c.Email,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 Status = r.Status,
                                 CustomerId = c.CustomerId,
                                 CarId = cr.CarId,
                             }).Where(r => r.OrderId == id).ToList();

            return getRent;
        }
    }
}
