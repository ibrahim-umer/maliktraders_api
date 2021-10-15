
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MalikTraders.Models
{
    public class ShopAccountPaymentHistory
    {
        public int id { get; set; }
        public string PaymentTitle { get; set; }
        public int AmountRecived { get; set; }
        public int AmountPaid { get; set; }
        public string PaymentDescription { get; set; }
        public DateTime TransectionDate { get; set; }
        [ForeignKey("ShopAccount")]
        public int ShopAccountId { get; set; }
    }
}
