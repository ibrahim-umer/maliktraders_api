using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MalikTraders.Models
{
    public class UserDetails
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string CNIC { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime Registration_Date { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
