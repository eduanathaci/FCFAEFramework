using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FCFAEFramework.Models
{
    public class Consent
    {
        public int ID { get; set; }
        //public Service Service { get; set; }

        [Column("Description")]
        public string Purpose { get; set; }
        public DateTime? InsertDate { get; set; }


        [ForeignKey("Data")]
        public int DataID { get; set; }
        public Data Data { get; set; }

        [ForeignKey("Service")]
        public int ServiceID { get; set; }
        public Service Service { get; set; }


    }


}