using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Model
{
    public class ShippingRate : BaseEntity
    {
        public decimal ShippingCost { get; set; }

        public string State { get; set; }
    }
}
