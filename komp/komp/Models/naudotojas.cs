using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace komp.Models
{
    public class naudotojas
    {
        [Required(ErrorMessage = "Blogi duomenys")]
        public string vardas { get; set; }
        [Required(ErrorMessage = "Blogi duomenys")]
        public string pavarde { get; set; }
        [Required(ErrorMessage = "Blogi duomenys")]
        public string elpastas { get; set; }
        [Required(ErrorMessage = "Blogi duomenys")]
        public string prisijungimoVardas { get; set; }
        [Required(ErrorMessage = "Blogi duomenys")]
        public string slaptazodis { get; set; }
        [Required(ErrorMessage = "Blogi duomenys")]
        public string telnumeris { get; set; }
        public string adresas { get; set; }
        public string role { get; set; }
        public int id { get; set;}
    }
}