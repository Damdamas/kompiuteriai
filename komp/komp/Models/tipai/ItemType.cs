using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace komp.Models.tipai
{
    public static class ItemType
    {
        public static string Case { get { return "korpusas"; } }
        public static string Motherboard { get { return "pagrindinė plokštė"; } }
        public static string CPU { get { return "procesorius"; } }
        public static string GPU { get { return "vaizdo plokštė"; } }
        public static string RAM { get { return "ram"; } }
        public static string MemoryDevice { get { return "atminties įrenginys"; } }
        public static string Cooler { get { return "aušintuvas"; } }
        public static string PS { get { return "maitinimo blokas"; } }
        public static string Monitor { get { return "monitorius"; } }
        public static string Mouse { get { return "pelė"; } }
        public static string Keyboard { get { return "klaviatūra"; } }
    }
}