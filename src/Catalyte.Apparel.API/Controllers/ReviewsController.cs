using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.Data.Model;
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
        [HttpGet("{reviewId}")]
        public async Task<ActionResult<ReviewsDTO>> GetReviewByIdAsync(int reviewId)
        {
            _logger.LogInformation($"Request received for GetReviewByIdAsync for id: {reviewId}");
            var review = await _reviewsProvider.GetReviewByIdAsync(reviewId);
            var reviewsDTOs = _mapper.Map<ReviewsDTO>(review);

            return Ok(reviewsDTOs);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReviewsDTO>> UpdateReviewByIdAsync(int id, [FromBody] ReviewsDTO reviewToUpdate)
        {
            _logger.LogInformation($"Request received for UpdateReviewByIdAsync for id: {id}");
            var review = _mapper.Map<Review>(reviewToUpdate);
            var updatedReview = await _reviewsProvider.UpdateReviewAsync(id, review);
            var reviewsDTOs = _mapper.Map<ReviewsDTO>(updatedReview);
            return Ok(reviewsDTOs);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<ReviewsDTO>>> DeleteReviewByIdAsync(int id)
        {
            _logger.LogInformation($"Request received for DeleteReviewByIdAsync for id: {id}");
            await _reviewsProvider.DeleteReviewByIdAsnc(id);

            //return Ok();
            var reviews = await _reviewsProvider.GetAllReviewsAsync();
            var reviewsDTOs = _mapper.Map<IEnumerable<ReviewsDTO>>(reviews);

            return Ok(reviewsDTOs);
        }

        [HttpPost]
        public async Task<ActionResult<List<ReviewsDTO>>> CreateReviewAsync([FromBody] ReviewsDTO model)
        {
            _logger.LogInformation("Request received for CreatePromo");

            var newReview = _mapper.Map<Review>(model);
            var savedPromo = await _reviewsProvider.CreateReviewAsync(newReview);
            var reviewDTO = _mapper.Map<ReviewsDTO>(savedPromo);
            return Created($"/reviews/", reviewDTO);
        }

    }
}
