using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MalikTraders.Models
{
    public class AccDetails
    {
        public int id { get; set; }
        public int payedAmount { get; set; }
        public DateTime PayingDate { get; set; }

        public int AccId { get; set; }
    }
}
