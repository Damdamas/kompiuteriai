using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace komp.Models.tipai
{
    public class OrderStatus
    {
        public string pateiktas {get { return "pateiktas"; } }

        public string priimtas { get { return "priimtas"; } }

        public string supakuotas { get { return "supakuotas"; } }

        public string pristatytas { get { return "pristatytas"; } }

        public string uzbaigtas { get { return "užbaigtas"; } }
    }
}