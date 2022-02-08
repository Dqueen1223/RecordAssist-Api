using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Catalyte.Apparel.Data.Model
{    /// <summary>
     /// Describes a sports apparel site review.
     /// </summary>
    public class Review : BaseEntity
    {
        [JsonRequired]
        public int Rating { get; set; }

        public string Title { get; set; }

        public string ReviewsDescription { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static IEqualityComparer<Review> ReviewComparer { get; } = new ReviewEqualityComparer();

        private sealed class ReviewEqualityComparer : IEqualityComparer<Review>
        {
            public bool Equals(Review x, Review y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Rating == y.Rating && x.Title == y.Title && x.ReviewsDescription == y.ReviewsDescription;
            }

            public int GetHashCode(Review obj)
            {
                var hashCode = new HashCode();
                hashCode.Add(obj.Rating);
                hashCode.Add(obj.Title);
                hashCode.Add(obj.ReviewsDescription);

                return hashCode.ToHashCode();
            }
        }
    }
}
