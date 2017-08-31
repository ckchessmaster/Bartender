using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ckingdon.Bartender.Models;

namespace ckingdon.Bartender.Data_Access
{
    public class BartenderInitializer : DropCreateDatabaseIfModelChanges<BartenderContext>
    {
        //Seed the database with data
        protected override void Seed(BartenderContext context)
        {
            var drinks = new List<Drink>
            {
                new Drink {Name="Sex on the Beach", Image="" },
                new Drink {Name="Whiskey Sour", Image="~/Content/Images/Whiskey-Sour.jpg" },
                new Drink {Name="Screwdriver", Image="" },
                new Drink {Name="Margarita", Image="" },
                new Drink {Name="Martini", Image="" },
                new Drink {Name="Mojito", Image="" },
                new Drink {Name="Gin and Tonic", Image="" },
                new Drink {Name="House IPA", Image="" },
                new Drink {Name="House Lager", Image="" }
            };

            drinks.ForEach(d => context.Drinks.Add(d));
            context.SaveChanges();
        }//end Seed

    }//end class BartenderInitializer
}//end namespace