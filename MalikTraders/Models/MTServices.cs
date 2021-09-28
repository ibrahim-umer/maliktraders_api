using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MalikTraders.Models
{
    public class MTServices
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Details { get; set; }

    }
}
