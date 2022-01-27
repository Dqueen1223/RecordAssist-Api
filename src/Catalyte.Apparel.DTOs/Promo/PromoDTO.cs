using System;

namespace Catalyte.Apparel.DTOs.Promos
{
    /// <summary>
    /// Describes a data transfer object for a promo
    /// </summary>
    public class PromoDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Discount { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
