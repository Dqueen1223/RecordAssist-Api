using System;

namespace Catalyte.Apparel.DTOs.Promos
{
    /// <summary>
    /// Describes a data transfer object for a promo
    /// </summary>
    public class PromoDTO
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public int? Discount { get; set; }

        public string Type { get; set; }

        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }
    }
}
