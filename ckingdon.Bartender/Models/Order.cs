using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ckingdon.Bartender.Models
{
    public class Order
    {
        //Primary Key
        public int OrderID { get; set; }

        //Foreign Key
        public virtual Drink Drink { get; set; }

        public DateTime TimeOrdered { get; set; }
        public String Customer { get; set; }
        public int CustomerPIN { get; set; }

        public bool isBeingMade { get; set; }
        public bool isReadyForPickup { get; set; }
    }//end Class Order
}//end namespace