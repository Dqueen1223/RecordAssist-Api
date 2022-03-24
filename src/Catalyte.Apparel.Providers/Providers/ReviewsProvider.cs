using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Catalyte.Apparel.Utilities.Validation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace Catalyte.Apparel.Providers.Providers
{
    /// <summary>
    /// This class provides the implementation of the IProductProvider interface, providing service methods for patients.
    /// </summary>
    public class ReviewsProvider : IReviewProvider
    {
        private readonly ILogger<ReviewsProvider> _logger;
        private readonly IReviewsRepository _ReviewsRepository;
        private readonly IPatientRepository _patientRepository;

        public ReviewsProvider(IReviewsRepository reviewsRepository, ILogger<ReviewsProvider> logger, IPatientRepository patientRepository)
        {
            _logger = logger;
            _ReviewsRepository = reviewsRepository;
            _patientRepository = patientRepository;
        }

        /// <summary>
        /// Asynchronously retrieves the review with the provided id from the database.
        /// </summary>
        /// <param name="reviewId">The id of the patient to retrieve.</param>
        /// <returns>The patient.</returns>
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
                review = await _ReviewsRepository.NoTrackingGetReviewByIdAsync(reviewId);
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
            //List<string> errors = Validation.ReviewValidation(updatedReview);
            //if (errors.Count > 0)
            //    throw new BadRequestException(string.Join(' ', errors));

            try
            {
                review = await _ReviewsRepository.UpdateReviewAsync(updatedReview);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            return review;
        }

        /// <summary>
        /// Asynchronously deletes the review with the provided id from the database.
        /// </summary>
        /// <param name="reviewId">The id of the patient to retrieve.</param>
        /// <returns>The review.</returns>
        public async Task DeleteReviewByIdAsnc(int reviewId)
        {
            Review review = await _ReviewsRepository.GetReviewByIdAsync(reviewId);
            if (review == null || review == default)
            {
                _logger.LogInformation($"Review with id: {reviewId} could not be found.");
                throw new NotFoundException($"Review {reviewId} could not be found.");
            }
            try
            {
                await _ReviewsRepository.DeleteReviewByIdAsync(reviewId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
        }

        /// <summary>
        /// Asynchronously deletes the review with the provided id from the database.
        /// </summary>
        /// <param name="newReview">The review being created.</param>
        /// <returns>The review.</returns>
        public async Task<Review> CreateReviewAsync(Review newReview)
        {
            Review savedReview;

            try
            {
                savedReview = await _ReviewsRepository.CreateReviewAsync(newReview);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            return savedReview;
        }

        public async Task<List<int>> GetReviewByProductIdAsync()
        {
            List<Review> review;
            IEnumerable<Patient> allPatients;
            var patientIds = new List<int>();

            try
            {
                allPatients = await _patientRepository.GetAllPatientsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            try
            {
                foreach (Patient patient in allPatients)
                {
                    review = await _ReviewsRepository.GetReviewByProductIdAsync(patient.Id);
                    if (review.Count > 0)
                    {
                        patientIds.Add(patient.Id);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return patientIds;

        }

    }


}