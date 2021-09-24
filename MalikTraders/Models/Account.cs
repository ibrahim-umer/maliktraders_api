using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MalikTraders.Models
{
    public class Account
    {
        public int id { get; set; }
        public string AccNumber { get; set; }
        public string BankName { get; set; }
        public int AccDetailsId { get; set; }
        public int AmountPayable { get; set; }
    }
}
