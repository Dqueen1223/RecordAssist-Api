using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.DTOs.Reviews;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Catalyte.Apparel.API.Controllers
{
    /// <summary>
    /// The ReviewsController exposes endpoints for review related actions.
    /// </summary>
    [ApiController]
    [Route("/reviews")]
    public class ReviewsController : ControllerBase
    {
        private readonly ILogger<ReviewsController> _logger;
        private readonly IReviewProvider _reviewsProvider;
        private readonly IMapper _mapper;

        public ReviewsController(
            ILogger<ReviewsController> logger,
            IReviewProvider reviewsProvider,
            IMapper mapper
        )
        {
            _logger = logger;
            _reviewsProvider = reviewsProvider;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewsDTO>>> GetAllReviewsAsync()
        {
            _logger.LogInformation("Request received for GetAllReviewsAsync");

            var reviews = await _reviewsProvider.GetAllReviewsAsync();
            var reviewsDTOs = _mapper.Map<IEnumerable<ReviewsDTO>>(reviews);

            return Ok(reviewsDTOs);
        }

        // /reviews/idNumber
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewsDTO>> GetReviewByIdAsync(int reviewId)
        {
            _logger.LogInformation($"Request received for GetReviewByIdAsync for id: {reviewId}");
            var review = await _reviewsProvider.GetReviewByIdAsync(reviewId);
            var reviewsDTOs = _mapper.Map<ReviewsDTO>(review);

            return Ok(reviewsDTOs);
        }

        // /reviews/delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReviewByIdAsync(int reviewId)
        {
            _logger.LogInformation($"Request received for DeleteReviewByIdAsync for id: {reviewId}");
            await _reviewsProvider.DeleteReviewByIdAsync(reviewId);

            return Ok();
        }

    }
}
