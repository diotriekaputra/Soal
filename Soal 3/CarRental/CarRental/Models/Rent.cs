﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    [Table("Tb_T_Rent")]
    public class Rent
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Status Status { get; set; }
        public string CustomerId { get; set; }
        public string EmployeeId { get; set; }
        public string CarId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Car Car { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual History History { get; set; }
    }
    public enum Status
    {
        Rented,
        Returned
    }
}
