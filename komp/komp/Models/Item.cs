﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace komp.Models
{
    public class Item
    {


        public int id { get; set; }



        [Required(ErrorMessage = "Privalomas langelis")]
        public string pavadinimas { get; set; }



        public float kaina { get; set; }



        public string aprasymas { get; set; }



        public string tipas { get; set; }



        public float reitingas { get; set; }



        public bool matomas { get; set; }
    }
}