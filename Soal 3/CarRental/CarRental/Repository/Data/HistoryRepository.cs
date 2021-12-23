using CarRental.Context;
using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Repository.Data
{
    public class HistoryRepository : GeneralRepository<MyContext, History, int>
    {
        private readonly MyContext myContext;
        public HistoryRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
