using System;

namespace Catalyte.Apparel.DTOs.Promos
{
    /// <summary>
    /// Describes a data transfer object for creating a promo
    /// </summary>
    public class CreatePromoDTO
    {
        public string Code { get; set; }

        public decimal? Discount { get; set; }

        public string Type { get; set; }

        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }
    }
}


