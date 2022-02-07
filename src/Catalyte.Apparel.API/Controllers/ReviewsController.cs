using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.API.DTOMappings;
using Catalyte.Apparel.DTOs.Purchases;
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
        private readonly IReviewsProvider _reviewsProvider;
        private readonly IMapper _mapper;

        public ReviewsController(
            ILogger<ReviewsController> logger,
            IReviewsProvider reviewsProvider,
            IMapper mapper
        )
        {
            _logger = logger;
            _reviewsProvider = reviewsProvider;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReviewsDTO>>> GetAllReviewsByEmailAsync(string email)
        {
            _logger.LogInformation("Request received for GetAllReviewsAsync");

            var reviews = await _reviewsProvider.GetAllReviewsByEmailAsync(email);
            var reviewsDTOs = _mapper.MapPurchasesToReviewsDtos(reviews);

            return Ok(reviewsDTOs);
        }
    }
}
