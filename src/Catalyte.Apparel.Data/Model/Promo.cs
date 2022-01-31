using System;

namespace Catalyte.Apparel.Data.Model
{
    /// <summary>
    /// Describes the object for a promotional discount
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
