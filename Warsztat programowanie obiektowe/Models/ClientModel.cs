using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warsztat_programowanie_obiektowe.Models
{
    public class ClientModel
    {
        [Key]
        public int ID_client { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public virtual ICollection<AdressModel> ID_adress { get; set; }

    }
}