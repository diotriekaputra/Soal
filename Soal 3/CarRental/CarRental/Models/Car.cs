﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    [Table("Tb_M_Car")]
    public class Car
    {
        [Key]
        public string CarId { get; set; }
        public string CarName { get; set; }
        public virtual ICollection<Rent> Rent { get; set; }
    }
}
