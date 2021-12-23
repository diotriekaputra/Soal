using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    [Table("Tb_T_History")]
    public class History
    {
        [Key]
        public int HistoryId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int OrderId { get; set; }
        public virtual Rent Rent { get; set; }
    }
}
