using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace komp.Models
{
    public class Cart
    {
        public string pavadinimas { get; set; }

        public DateTime sukurimoData { get; set; }
        
        public bool patvirtintas { get; set; }

    }
}