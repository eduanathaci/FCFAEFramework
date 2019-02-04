using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FCFAEFramework.Models
{
    public class Consent
    {
        [Key]
        [Column(Order =1)]
        public int ID { get; set; }
        public string Purpose { get; set; }
        public DateTime? InsertDate { get; set; }


        [ForeignKey("Data")]
        public int DataID { get; set; }
        public Data Data { get; set; }

        [Key]
        [Column(Order =2)]
        [ForeignKey("Service")]
        public int ServiceID { get; set; }
        public Service Service { get; set; }


    }


}