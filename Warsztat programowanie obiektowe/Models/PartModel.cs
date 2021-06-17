using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warsztat_programowanie_obiektowe.Models
{
    public class PartModel
    {
        [Key]
        public int ID_part { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public int ID_dealer { get; set; }
        public virtual ICollection<DealerModel> Dealer { get; set; }
       
    }
}