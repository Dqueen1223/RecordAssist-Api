using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.API.DTOMappings;
using Catalyte.Apparel.DTOs.Promos;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Catalyte.Apparel.API.Controllers
{
    /// <summary>
    /// The PurchasessController exposes endpoints for purchase related actions.
    /// </summary>
    [ApiController]
    [Route("/promo")]
    public class PromoController : ControllerBase
    {
        private readonly ILogger<PromoController> _logger;
        private readonly IPromoProvider _PromoProvider;
        private readonly IMapper _mapper;

        public PromoController(
            ILogger<PromoController> logger,
            IPromoProvider PromoProvider,
            IMapper mapper
        )
        {
            _logger = logger;
            _PromoProvider = PromoProvider;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<List<PromoDTO>>> CreatePromoAsync([FromBody] CreatePromoDTO model)
        {
            _logger.LogInformation("Request received for CreatePromo");

            var newPromo = _mapper.MapCreatePromoDtoToPromo(model);
            var savedPromo = await _PromoProvider.CreatePromoAsync(newPromo);
            var promoDTO = _mapper.MapPromoToPromoDto(savedPromo);
            return Created($"/promo/", promoDTO);
        }
    }
}
