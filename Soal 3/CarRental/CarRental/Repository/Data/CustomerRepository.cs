using CarRental.Context;
using CarRental.Models;
using CarRental.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Repository.Data
{
    public class CustomerRepository : GeneralRepository<MyContext, Customer, string>
    {
        private readonly MyContext myContext;
        public CustomerRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public int AddCustomer(AddCustomerVM addCustomerVM)
        {
            Customer customer = new Customer();
            var checkEmail = myContext.Customers.Where(x => x.Email == addCustomerVM.Email).FirstOrDefault();
            var checkPhone = myContext.Customers.Where(x => x.PhoneNumber == addCustomerVM.PhoneNumber).FirstOrDefault();
            customer.Email = addCustomerVM.Email;

            if (checkEmail != null)
            {
                return 2;
            }
            if (checkPhone != null)
            {
                return 3;
            }

            customer.CustomerId = addCustomerVM.CustomerId;
            customer.FirstName = addCustomerVM.FirstName;
            customer.LastName = addCustomerVM.LastName;
            customer.BirthDate = addCustomerVM.BirthDate;
            customer.Gender = (Models.Gender)addCustomerVM.Gender;
            customer.PhoneNumber = addCustomerVM.PhoneNumber;
            customer.Email = addCustomerVM.Email;
            customer.Address = addCustomerVM.Address;

            myContext.Customers.Add(customer);
            var result = myContext.SaveChanges();
            return result;
        }
        public IEnumerable<RentVM> GetRentStatus()
        {
            var payStatus = (from c in myContext.Customers
                             join r in myContext.Rent on
                             c.CustomerId equals r.CustomerId

                             select new RentVM
                             {
                                 OrderId = r.OrderId,
                                 CustomerId = c.CustomerId,
                                 FirstName = c.FirstName,
                                 LastName = c.LastName,
                                 PhoneNumber = c.PhoneNumber,
                                 Email = c.Email,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 Status = r.Status,
                             }).Where(r => r.Status == 0).ToList();
            return payStatus;
        }

        public IEnumerable<AddCustomerVM> GetIdProfile(string CustomerId)
        {
            var getProfile = (from c in myContext.Customers
                              select new AddCustomerVM
                              {
                                  CustomerId = c.CustomerId,
                                  FirstName = c.FirstName,
                                  LastName = c.LastName,
                                  Email = c.Email,
                                  PhoneNumber = c.PhoneNumber,
                                  Gender = (ViewModel.Gender)c.Gender,
                                  BirthDate = c.BirthDate,
                                  Address = c.Address,
                              }).Where(c => c.CustomerId == CustomerId).ToList();

            return getProfile;
        }
    }
}
