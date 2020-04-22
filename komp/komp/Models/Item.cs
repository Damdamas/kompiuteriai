using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace komp.Models
{
    public class Item
    {
        public string pavadinimas { get; set; }
        public string kaina { get; set; }
        public string aprasymas { get; set; }
        public string tipas { get; set; }
        public float reitingas { get; set; }
    }
}