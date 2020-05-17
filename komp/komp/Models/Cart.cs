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
        
        public IList<Item> prekes { get; set; }

        public int id { get; set; }

        public Cart()
        {
            pavadinimas = "";
            sukurimoData = DateTime.Now;
            patvirtintas = false;
            prekes = new List<Item>();
            id = 0;
        }
    }
}