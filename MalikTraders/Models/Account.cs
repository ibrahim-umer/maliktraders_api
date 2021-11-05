using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MalikTraders.Models
{
    public class Account
    {
        
        public int id { get; set; }
        public string AccNumber { get; set; }
        public string BankName { get; set; }
        [Required]
        public int AmountPayable { get; set; }
        [Required]
        public int MonthlyInstalment { get; set; }
        public DateTime ClosingDate { get; set; }
        public bool isAccClosed { get; set; }
        public string ClosingDescription { get; set; }
        public int Userid { get; set; }
        [Required]
        public int MTServiceId { get; set; }
        [ForeignKey("AccId")]
        public IList<AccDetails> AccPaymentDetails { get; set; }
        
    }
}
