using Catalyte.Apparel.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Catalyte.Apparel.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for product repository methods.
    /// </summary>
    public interface IReviewsRepository
    {
        Task<Review> GetReviewByIdAsync(int reviewsId);

        Task<Review> UpdateReviewAsync(Review review);

        Task<IEnumerable<Review>> GetAllReviewsAsync();

        Task DeleteReviewByIdAsync(int reviewId);

    }
}