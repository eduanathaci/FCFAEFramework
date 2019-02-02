using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FCFAEFramework.Models
{
    public class Data
    {
        public int ID { get; set; }

        [Display(Name ="Name Of Data")]
        public string NameOfData { get; set; }


        [Display(Name = "Type Of Data")]
        public string TypeOfData { get; set; }

    }
}