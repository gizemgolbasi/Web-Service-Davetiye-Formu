﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppBhirtday.Models
{
    public class Davetiye
    {
        [Required]
        public string Ad { get; set; }

        [Required]
        public string Eposta { get; set; }

        [Required]
        public bool KatilmeDurumu{ get; set; }
    }
}