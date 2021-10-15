using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MalikTraders.Models
{
    public class ShopAccount
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public bool? IsDefaulter { get; set; }
        public int CurrentPayment { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User ShopAccUser { get; set; }

        [ForeignKey("ShopAccountId")]
        public ICollection<ShopAccountPaymentHistory> ShopAccountPayments { get; set; }

    }
}
