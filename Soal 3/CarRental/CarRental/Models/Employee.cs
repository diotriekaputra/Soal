using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    [Table("Tb_T_Employee")]
    [Index(nameof(Employee.PhoneNumber), IsUnique = true)]
    [Index(nameof(Employee.Email), IsUnique = true)]

    public class Employee
    {
        [Key]
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Rent> Rent { get; set; }
    }
}
