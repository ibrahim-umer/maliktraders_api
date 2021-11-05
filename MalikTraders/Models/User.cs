using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MalikTraders.Models
{
    public class User
    {
        public int id { get; set; }
        public string GUID { get; set; }
        [EmailAddress]
        [Required]
        public string email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool isUserDisabled { get; set; }
        [Required]
        public string Role { get; set; }
        public UserDetails UserDetail { get; set; }
        [ForeignKey("Userid")]
        public IList<Account> SchemeAccounts { get; set; }
        [ForeignKey("Userid")]
        public IList<Notification> UserNotification { get; set; }
        public ShopAccount UserShopAccount { get; set; }

    }
}
