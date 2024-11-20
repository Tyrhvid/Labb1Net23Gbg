using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class Order
    {
        public int Id { get; set; } // Unikt ID för order
        public Order OrderObject { get; set; } // Namn på order
    }
}
