using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCFAEFramework.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int BusinessNo { get; set; }
        public int FiscalNo { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}