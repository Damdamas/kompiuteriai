using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace komp.Models
{
    public class Order
    {
        [Required]
        public string vardas { get; set; }
        [Required]
        public string pavarde { get; set; }
        [Required]
        public string elpastas { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "įveskite galiojanti telefono numerį.")]
        public string telnumeris { get; set; }
        [Required]
        public string adresas { get; set; }

        public DateTime data { get; set; }
        [Required]
        public string atsiemimas { get; set; }
        [Required]
        public string mokejimas { get; set; }
        public string busena { get; set; }

        public int krepselisId { get; set;}
        
        public string id { get; set; }
    }
}