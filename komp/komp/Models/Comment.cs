using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace komp.Models
{
    public class Comment
    {
        public DateTime sukurimoData { get; set; }

        public string turinys { get; set; }
        public int naudotojasId { get; set; }
        public int prekeId { get; set; }
        public int id { get; set; }
    }
}