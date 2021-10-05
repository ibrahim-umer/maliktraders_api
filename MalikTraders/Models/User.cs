using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
        [Required]
        public string Role { get; set; }
        public UserDetails userDetails { get; set; }
        [ForeignKey("Userid")]
        public ICollection<Account> accounts { get; set; }

    }
}
