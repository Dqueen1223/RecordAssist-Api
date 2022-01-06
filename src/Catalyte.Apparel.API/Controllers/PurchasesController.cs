﻿using System.Collections.Generic;
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
    /// The PurchasessController exposes endpoints for purchase related actions.
    /// </summary>
    [ApiController]
    [Route("/purchases")]
    public class PurchasesController : ControllerBase
    {
        private readonly ILogger<PurchasesController> _logger;
        private readonly IPurchaseProvider _purchaseProvider;
        private readonly IMapper _mapper;

        public PurchasesController(
            ILogger<PurchasesController> logger,
            IPurchaseProvider purchaseProvider,
            IMapper mapper
        )
        {
            _logger = logger;
            _purchaseProvider = purchaseProvider;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PurchaseDTO>>> GetAllPurchasesByEmailAsync(string email)
        {
            _logger.LogInformation("Request received for GetAllPurchasesAsync");

            var purchases = await _purchaseProvider.GetAllPurchasesByEmailAsync(email);
            var purchaseDTOs = _mapper.MapPurchasesToPurchaseDtos(purchases);

            return Ok(purchaseDTOs);
        }

        [HttpPost]
        public async Task<ActionResult<List<PurchaseDTO>>> CreatePurchaseAsync([FromBody] CreatePurchaseDTO model)
        {
            _logger.LogInformation("Request received for CreatePurchase");

            var newPurchase = _mapper.MapCreatePurchaseDtoToPurchase(model);

            List<LineItemDTO> inactiveProducts = await _purchaseProvider.CheckForInactiveProductsAsync(newPurchase);
            if (inactiveProducts.Count > 0)
            {
                return UnprocessableEntity(inactiveProducts);
            }
            else
            {
                var savedPurchase = await _purchaseProvider.CreatePurchasesAsync(newPurchase);
                var purchaseDTO = _mapper.MapPurchaseToPurchaseDto(savedPurchase);
                return Created($"/purchases/", purchaseDTO);
            }
        }
    }
}
