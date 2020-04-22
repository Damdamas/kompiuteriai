using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace komp.Models.tipai
{
    public static class Role
    {
        public static string Admin { get { return "administratorius"; } }
        public static string User { get { return "registruotas naudotojas"; } }
        public static string Anonymous { get { return "svecias"; } }
    }
}