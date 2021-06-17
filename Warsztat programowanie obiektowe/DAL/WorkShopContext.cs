using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Warsztat_programowanie_obiektowe.Models;

namespace Warsztat_programowanie_obiektowe.DAL
{
    public class WorkShopContext : DbContext
    {
        public DbSet<AdressModel> adresy { get; set; }
        public DbSet<WorkersModel> workers { get; set; }
        public DbSet<ClientModel> clients {get; set;}
        public DbSet<CarModel> cars {get; set;}
        public DbSet<DealerModel> dealers { get; set; }
        public DbSet<MendingModel> mendings { get; set; }
        public DbSet<MendingListModel> mendignList { get; set; }
        public DbSet<PartModel> parts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           
        }
    }
}