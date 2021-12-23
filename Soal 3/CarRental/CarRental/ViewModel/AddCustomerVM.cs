using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.ViewModel
{
    public class AddCustomerVM
    {
        [Required]
        public string CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [Required]
        public string PhoneNumber { get; set; }
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Address { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}
