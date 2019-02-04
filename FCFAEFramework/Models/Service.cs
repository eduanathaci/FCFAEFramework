using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FCFAEFramework.Models
{
    public class Service
    {
        public int ID { get; set; }
        [Column(Order =1)]

        [Display(Name="Service Name")]
        public string ServiceName { get; set; }
        public string Banner { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }


        [ForeignKey("Company")]
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public List<Client> Clients { get; set; }

    }
}