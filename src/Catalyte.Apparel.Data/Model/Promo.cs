using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static IEqualityComparer<Promo> PromoComparer { get; } = new PromoEqualityComparer();

        private sealed class PromoEqualityComparer : IEqualityComparer<Promo>
        {
            public bool Equals(Promo x, Promo y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Code == y.Code && x.Discount == y.Discount && x.Type == y.Type && x.StartDate == y.StartDate && x.EndDate == y.EndDate;
            }

            public int GetHashCode(Promo obj)
            {
                var hashCode = new HashCode();
                hashCode.Add(obj.ID);
                hashCode.Add(obj.Code);
                hashCode.Add(obj.Discount);
                hashCode.Add(obj.Type);
                hashCode.Add(obj.StartDate);
                hashCode.Add(obj.EndDate);

                return hashCode.ToHashCode();
            }
        }
    }
}
