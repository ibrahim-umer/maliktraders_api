using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MalikTraders.Models
{
    public class AccDetails
    {
        public int id { get; set; }
        [Required]
        public int payedAmount { get; set; }
        [Required]
        public DateTime PayingDate { get; set; }
        [Required]
        public int AccId { get; set; }
        [Required]
        public int PostedByUserId { get; set; }
     }
}
