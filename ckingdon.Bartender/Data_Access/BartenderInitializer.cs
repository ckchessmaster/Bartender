using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ckingdon.Bartender.Models;

namespace ckingdon.Bartender.Data_Access
{
    public class BartenderInitializer : DropCreateDatabaseAlways<BartenderContext>
    {
        //Seed the database with data
        protected override void Seed(BartenderContext context)
        {
            var drinks = new List<Drink>
            {
                new Drink {Name="Sex on the Beach", Image="../Content/Images/Sex-On-The-Beach.jpg" },
                new Drink {Name="Whiskey Sour", Image="../Content/Images/Whiskey-Sour.jpg" },
                new Drink {Name="Screwdriver", Image="../Content/Images/Screwdriver.jpg" },
                new Drink {Name="Margarita", Image="../Content/Images/Margarita.jpg" },
                new Drink {Name="Martini", Image="../Content/Images/Martini.jpeg" },
                new Drink {Name="Mojito", Image="../Content/Images/Mojito.jpg" },
                new Drink {Name="Gin and Tonic", Image="../Content/Images/Gin-And-Tonic.jpg" },
                new Drink {Name="House IPA", Image="../Content/Images/IPA.jpg" },
                new Drink {Name="House Lager", Image="../Content/Images/Lager.jpg" }
            };

            drinks.ForEach(d => context.Drinks.Add(d));
            context.SaveChanges();
        }//end Seed

    }//end class BartenderInitializer
}//end namespace