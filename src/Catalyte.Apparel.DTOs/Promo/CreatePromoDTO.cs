using System;

namespace Catalyte.Apparel.DTOs.Promos
{
    /// <summary>
    /// Describes a data transfer object for creating a promo
    /// </summary>
    public class CreatePromoDTO
    {
        public string Code { get; set; }

        public int Discount { get; set; }

        public string Type { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}


