﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.DTOs.Purchases;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Catalyte.Apparel.API.Controllers
{
    /// <summary>
    /// The LineItemsController exposes endpoints for LineItems related actions.
    /// </summary>
    [ApiController]
    [Route("/lineitems")]
    public class LineItemsController : ControllerBase
    {
        private readonly ILogger<LineItemsController> _logger;
        private readonly ILineItemsProvider _LineItemsProvider;
        private readonly IMapper _mapper;

        public LineItemsController(
            ILogger<LineItemsController> logger,
            ILineItemsProvider LineItemsProvider,
            IMapper mapper
        )
        {
            _logger = logger;
            _LineItemsProvider = LineItemsProvider;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LineItemDTO>> GetLineItemsByProductIdAsync(int id)
        {
            _logger.LogInformation($"Request received for GetLineItemsByProductIdAsync for id: {id}");

            var lineItem = await _LineItemsProvider.GetLineItemsByProductIdAsync(id);
            var lineItemDTO = _mapper.Map<LineItemDTO>(lineItem);

            return Ok(lineItemDTO);
        }

    }
}
