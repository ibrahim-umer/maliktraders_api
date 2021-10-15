using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MalikTraders.Models
{
    public class Notification
    {
        public int id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string IsRead { get; set; }
        public DateTime PublishingDate { get; set; }
        public DateTime ExpiringDate { get; set; }
        [ForeignKey("User")]
        public int Userid { get; set; }

    }
}
