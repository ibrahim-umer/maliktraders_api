using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MalikTraders.Models
{
    public class User
    {
        public int id { get; set; }
        public string GUID { get; set; }
        public string email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        [ForeignKey("id")]
        public UserDetails userDetailsId { get; set; }
        [ForeignKey("Userid")]
        public ICollection<Account> account { get; set; }
    }
}
