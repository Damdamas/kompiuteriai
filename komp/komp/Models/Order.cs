using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace komp.Models
{
    public class Order
    {
        public string vardas { get; set; }

        public string pavarde { get; set; }

        public string elpastas { get; set; }

        public string adresas { get; set; }

        public DateTime data { get; set; }

        public string atsiemimas { get; set; }

        public string mokejimas { get; set; }

        public string busena { get; set; }
    }
}