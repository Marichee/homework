using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class MovieOrderModel
    {
       
        public int OrderID { get; set; }
        public string Movie { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

    }

}
