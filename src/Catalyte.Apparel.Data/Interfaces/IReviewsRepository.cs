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
        Task<Review> GetReviewsByIdAsync(int reviewsId);

        Task<IEnumerable<Review>> GetReviewsAsync(int rating, string title, string ReviewsDescription);


        Task<List<string>> GetAllUniqueReviewTitlesAsync();

        Task<List<string>> GetAllUniqueReviewsDescriptionAsync();

    }
}