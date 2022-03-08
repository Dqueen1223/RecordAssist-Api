using Catalyte.Apparel.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Interfaces
{ /// <summary>
  /// This interface provides an abstraction layer for review related service methods.
  /// </summary>
    public interface IReviewProvider
    {
        Task<Review> GetReviewByIdAsync(int reviewId);

        Task<IEnumerable<Review>> GetAllReviewsAsync();

        Task<Review> UpdateReviewAsync(int reviewId, Review updatedReview);

        Task DeleteReviewByIdAsnc(int reviewId);

        Task<Review> CreateReviewAsync(Review model);
        Task<List<int>> GetReviewByProductIdAsync();
    }
}
