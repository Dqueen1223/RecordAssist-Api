using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.SeedData
{
    public class ReviewFactory
    {
        Random _rand = new();

        private List<int> _rating = new() // random ratings for each review
        {
            1,
            2,
            3,
            4,
            5
        };
        private List<string> _title = new() //  random titles for each review
        {
            "Horrible",
            "Wonderful!",
            "IDK"
        };
        private List<string> _reviewsDescription = new() // random descriptions for each review
        {
            "this product is great",
            "this product is bad",
            "would definitely recommend",
            "don't waste your time",
            "NEVER AGAIN"
        };
        /// Returns a random rating from the list of ratings.
        /// </summary>
        /// <returns>A review rating</returns>
        /// Uses random generators to build a products.
        /// </summary>
        /// <param name="id">ID to assign to the product.</param>
        /// <returns>A randomly generated product.</returns>
        private Review CreateRandomReview(int id)
        {
            var rating = _rating[_rand.Next(0, _rating.Count)];
            var title = _title[_rand.Next(0, _title.Count)];
            var reviewsDescription = _reviewsDescription[_rand.Next(0, _reviewsDescription.Count)];



            return new Review
            {
                Rating = rating,
                Title = title,
                ReviewsDescription= reviewsDescription
            };
        }

    }
}
