using System;
using System.Collections.Generic;

namespace Catalyte.Apparel.Data.Model
{
    /// <summary>
    /// Describes the object for the delivery address of the purchase.
    /// </summary>
    public class Promo : BaseEntity
    {
        public string Name { get; set; }

        public string Discount { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
