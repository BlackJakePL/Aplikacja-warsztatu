using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warsztat_programowanie_obiektowe.Models
{
    public class DealerModel
    {
        [Key]
        public int ID_dealer { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public int NIP { get; set; }

    }
}