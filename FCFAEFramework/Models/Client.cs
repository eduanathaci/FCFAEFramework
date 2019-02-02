using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FCFAEFramework.Models
{
    public class Client
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [MaxLength(15)]
        public string PhoneNo { get; set; }
        [MaxLength(15)]
        public string PersonalNo { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
        public DateTime? InsertDate { get; set; }
        public List<Service> Services { get; set; }
    }
}