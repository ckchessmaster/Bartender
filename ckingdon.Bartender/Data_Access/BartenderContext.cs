using ckingdon.Bartender.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ckingdon.Bartender.Data_Access
{
    public class BartenderContext : DbContext
    {
        public BartenderContext() : base("BartenderContext") { }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<Order> ProductionQueue { get; set; }
        //public DbSet<Order> PickupQueue { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }//end OnModelCreating

    }//end class BartenderContext
}//end namespace