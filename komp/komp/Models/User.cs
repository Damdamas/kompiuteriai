using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace komp.Models
{
    public class User
    {
        [Required(ErrorMessage = "Privalomas langelis")]
        [RegularExpression(@"^\p{L}+$", ErrorMessage = "Varde gali būti tik raidės")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Vardas tarp: 1-50 simbolių ")]
        [DisplayName("Vardas")]
        public string vardas { get; set; }


        [DisplayName("Pavardė")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Pavardė tarp: 1-50 simbolių")]
        [Required(ErrorMessage = "Privalomas langelis")]
        [RegularExpression(@"^\p{L}+$", ErrorMessage = "Pavardėje gali būti tik raidės")]
        public string pavarde { get; set; }


        [DisplayName("El. Paštas")]
        [StringLength(254, MinimumLength = 6, ErrorMessage = "El. paštas tarp: 6-254 simbolių")]
        [Required(ErrorMessage = "Privalomas langelis")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Blogas el. pašto formatas")]
        public string elpastas { get; set; }


        [DisplayName("Slapyvardis")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Prisijungimo vardas tarp: 3-20 simbolių ")]
        [Required(ErrorMessage = "Privalomas langelis")]
        public string prisijungimoVardas { get; set; }


        [DisplayName("Slaptažodis")]
        [Required(ErrorMessage = "Privalomas langelis")]
        [StringLength(64, MinimumLength = 5, ErrorMessage = "Slaptažodis turi būti: 5-50 ilgio ")]
        public string slaptazodis { get; set; }


        [DisplayName("Tel. Nr.")]
        [Required(ErrorMessage = "Privalomas langelis")]
        [StringLength(16, ErrorMessage = "Per daug simbolių Max-16")]
        [RegularExpression(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", ErrorMessage = "Neegzistuojantis telefono numeris")]
        public string telnumeris { get; set; }

        [DisplayName("Adresas")]
        [Required(ErrorMessage = "Privalomas langelis")]
        [StringLength(1024, ErrorMessage = "Per daug simbolių adrese Max-1024")]
        public string adresas { get; set; }


        public string role { get; set; }
        public int id { get; set;}

        public User SessionUser()
        {
            var usr = new User();
            usr.id = id;
            usr.role = role;
            usr.vardas = vardas;
            usr.pavarde = pavarde;
            return usr;
        }
    }
}