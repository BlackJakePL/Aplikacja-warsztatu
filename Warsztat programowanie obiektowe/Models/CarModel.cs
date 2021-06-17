using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Web;

namespace Warsztat_programowanie_obiektowe.Models
{
    public class CarModel
    {
        [Key]
        public string  VIN { get; set; }
        public string ID_client { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Power { get; set; }
        public int Year { get; set; }
        public string fuel { get; set; }
       
        public override string ToString()
        {
            return VIN + " " + Make + " " + Model + " " + Year + " " + fuel;
        }
    }
}