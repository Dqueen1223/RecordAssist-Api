using System;
using System.ComponentModel.DataAnnotations;

namespace Catalyte.Apparel.Data.Model
{
    /// <summary>
    /// Describes the object for a promotional discount
    /// </summary>
    public class Promo
    {
        [Key]
        public int ID  { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int Discount { get; set; }

        public string Type { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
