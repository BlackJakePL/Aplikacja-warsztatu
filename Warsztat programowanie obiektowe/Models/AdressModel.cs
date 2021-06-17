using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warsztat_programowanie_obiektowe.Models
{
    public class AdressModel
    {
        [Key]
        public int ID_adress { get; set; }
        public string City { get; set; }
        public string  ZipCode { get; set; }
        public string Street { get; set; }
        public string BuildingNo { get; set; }
        public string FlatNo { get; set; }

        public override string ToString()
        {
            return City + " " + Street + " " + BuildingNo + " " + FlatNo;
        }

    }
}