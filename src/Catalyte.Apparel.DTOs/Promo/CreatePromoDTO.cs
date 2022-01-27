using System;

namespace Catalyte.Apparel.DTOs.Promos
{
    /// <summary>
    /// Describes a data transfer object for creating a promo
    /// </summary>
    public class CreatePromoDTO
    {

        public string Name { get; set; }

        public string Discount { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}


