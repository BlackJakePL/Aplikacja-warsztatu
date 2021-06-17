using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warsztat_programowanie_obiektowe.ViewModel
{
    public class WorkshopViewModel
    {
        public IEnumerable<IdentityRole> roles { get; set; }
    }
}