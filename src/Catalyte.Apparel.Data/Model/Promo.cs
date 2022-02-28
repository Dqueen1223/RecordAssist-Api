﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Catalyte.Apparel.Data.Model
{
    /// <summary>
    /// Describes the object for a promotional discount
    /// </summary>
    public class Promo
    {
        [Key]
        public int ID { get; set; }

        public string Code { get; set; }

        public decimal? Discount { get; set; }

        public string Type { get; set; }

        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }
    }
}
