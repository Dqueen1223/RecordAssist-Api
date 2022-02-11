using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace Catalyte.Apparel.Providers.Providers
{
    /// <summary>
    /// This class provides the implementation of the IProductProvider interface, providing service methods for products.
    /// </summary>
    public class ReviewsProvider : IReviewProvider
    {
        private readonly ILogger<ReviewsProvider> _logger;
        private readonly IReviewsRepository _ReviewsRepository;

        public ReviewsProvider(IReviewsRepository reviewsRepository, ILogger<ReviewsProvider> logger)
        {
            _logger = logger;
            _ReviewsRepository = reviewsRepository;
        }

        /// <summary>
        /// Asynchronously retrieves the review with the provided id from the database.
        /// </summary>
        /// <param name="reviewId">The id of the product to retrieve.</param>
        /// <returns>The product.</returns>
        public async Task<Review> GetReviewByIdAsync(int reviewId)
        {
            Review review;

            try
            {
                review = await _ReviewsRepository.GetReviewByIdAsync(reviewId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            
            if (review == null || review == default)
            {
                _logger.LogInformation($"Review with id: {reviewId} could not be found.");
                throw new NotFoundException($"Review {reviewId} could not be found.");
            }
            return review;

        }
        /// <summary>
        /// Asynchronously retrieves all reviews from the database.
        /// </summary>
        /// <returns>All reviews in the database.</returns>
        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            IEnumerable<Review> reviews;

            try
            {
                reviews = await _ReviewsRepository.GetAllReviewsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return reviews;
        }
        /// <summary>
        /// Asynchronously updates the review with the provided id from the database.
        /// </summary>
        /// <param name="updatedReview">The updated review.</param>
        /// <returns>The review.</returns>
        public async Task<Review> UpdateReviewAsync(int reviewId, Review updatedReview)
        {
            Review review;

            try
            {
                //review = await _ReviewsRepository.GetReviewByIdAsync(reviewId);
                review = await _ReviewsRepository.UpdateReviewAsync(updatedReview);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (review == null || review == default)
            {
                _logger.LogInformation($"Review with id: {reviewId} could not be found.");
                throw new NotFoundException($"Review {reviewId} could not be found.");
            }
            return review;

        }

    }


}