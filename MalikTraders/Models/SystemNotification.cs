using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MalikTraders.Models
{
    public class SystemNotification
    {
        public int id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public DateTime PublishingDate { get; set; }
        public DateTime ExpiringDate { get; set; }
    }
}
