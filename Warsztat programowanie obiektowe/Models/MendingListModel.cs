using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warsztat_programowanie_obiektowe.Models
{
    public class MendingListModel
    {
        [Key]
        public int ID_row { get; set; }
        public int ID_mending { get; set; }
        public int ID_part { get; set; }
 
    }
}