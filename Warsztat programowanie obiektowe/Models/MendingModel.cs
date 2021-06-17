using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warsztat_programowanie_obiektowe.Models
{
    public class MendingModel
    {
        [Key]
        public int ID_mending { get; set; }
        public virtual ICollection<WorkersModel> Worker { get; set; }
        public virtual ICollection<CarModel> Car { get; set; }
        public virtual IEnumerable<PartModel> List { get; set; }
        public DateTime MendingDate { get; set; }
        public float MendingTime { get; set; }
        public string MendingState { get; set; }
        public string VIN { get; set; }
        public int ID_worker { get; set; }
    }
}