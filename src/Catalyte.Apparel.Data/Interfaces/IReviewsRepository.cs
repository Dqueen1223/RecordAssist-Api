﻿using Catalyte.Apparel.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for product repository methods.
    /// </summary>
    public interface IReviewsRepository
    {
        Task<Review> GetReviewByIdAsync(int reviewsId);

        Task<Review> NoTrackingGetReviewByIdAsync(int reviewId);


        Task<Review> UpdateReviewAsync(Review review);

        Task<IEnumerable<Review>> GetAllReviewsAsync();

        Task DeleteReviewByIdAsync(int reviewId);

        Task<Review> CreateReviewAsync(Review model);

        Task<List<Review>> GetReviewByProductIdAsync(int productId);
    }
}