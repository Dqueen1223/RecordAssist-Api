using Catalyte.Apparel.Data.Model;
using System;
using System.Collections.Generic;

namespace Catalyte.Apparel.Data.SeedData
{
    /// <summary>
    /// This class provides tools for generating random reviews.
    /// </summary>
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
            "NEVER AGAIN",
            "life changing"
        };

        /// <summary>
        /// Generates a number of random reviews based on input.
        /// </summary>
        /// <param name="numberOfReviews">The number of random reviews to generate.</param>
        /// <returns>A list of random products.</returns>
        public List<Review> GenerateRandomReview(int numberOfReviews)
        {

            var reviewList = new List<Review>();

            for (var i = 0; i <= numberOfReviews; i++)
            {
                reviewList.Add(CreateRandomReview(i + 1));
            }

            return reviewList;
        }
        private Random gen = new Random();
        // <summary>
        // Generates a random date starting from the year 2021 into the current year.
        // </summary>
        // <returns> A list of randomly generated dates
        DateTime RandomDay()
        {
            DateTime start = new DateTime(2021, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
        /// Returns a random rating from the list of ratings.
        /// </summary>
        /// <returns>A review rating</returns>
        /// Uses random generators to build a random review.
        /// </summary>
        /// <param name="id">ID to assign to the review.</param>
        /// <returns>A randomly generated product.</returns>
        private Review CreateRandomReview(int id)
        {
            var rating = _rating[_rand.Next(0, _rating.Count)];
            var title = _title[_rand.Next(0, _title.Count)];
            var reviewsDescription = _reviewsDescription[_rand.Next(0, _reviewsDescription.Count)];
            var productId = _rand.Next(1, 1000);



            return new Review
            {
                Id = id,
                Rating = rating,
                Title = title,
                ReviewsDescription = reviewsDescription,
                Email = "customer@customer.home",
                ProductId = productId,
                DateCreated = RandomDay(),
                DateModified = DateTime.Now

            };
        }


    }
}
