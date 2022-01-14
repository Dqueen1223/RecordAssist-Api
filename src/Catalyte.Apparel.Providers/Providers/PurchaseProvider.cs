﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using Catalyte.Apparel.Utilities.Validation;
using System.Linq;

namespace Catalyte.Apparel.Providers.Providers
{
    /// <summary>
    /// This class provides the implementation of the IPurchaseProvider interface, providing service methods for purchases.
    /// </summary>
    public class PurchaseProvider : IPurchaseProvider
    {
        private readonly ILogger<PurchaseProvider> _logger;
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseProvider(IPurchaseRepository purchaseRepository, ILogger<PurchaseProvider> logger)
        {
            _logger = logger;
            _purchaseRepository = purchaseRepository;
        }

        /// <summary>
        /// Retrieves all purchases from the database.
        /// </summary>
        /// <param name="page">Number of pages.</param>
        /// <param name="pageSize">How many purchases per page.</param>
        /// <returns>All purchases.</returns>
        public async Task<IEnumerable<Purchase>> GetAllPurchasesAsync()
        {
            List<Purchase> purchases;

            try
            {
                purchases = await _purchaseRepository.GetAllPurchasesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return purchases;
        }

        /// <summary>
        /// Persists a purchase to the database.
        /// </summary>
        /// <param name="model">PurchaseDTO used to build the purchase.</param>
        /// <returns>The persisted purchase with IDs.</returns>
        public async Task<Purchase> CreatePurchasesAsync(Purchase newPurchase)
        {
            Purchase savedPurchase;

            var inactiveProducts = await CheckForInactiveProductsAsync(newPurchase);
            if (inactiveProducts != string.Empty)
            {
                throw new UnprocessableEntityException("Cannot purchase inactive products:  "
                    + inactiveProducts);
            }

            List<string> errors = Validation.CreditCardValidation(newPurchase);
            if (errors.Count > 0)
                throw new BadRequestException(string.Join(' ', errors));

            try
            {
                savedPurchase = await _purchaseRepository.CreatePurchaseAsync(newPurchase);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            return savedPurchase;
        }

        /// <summary>
        /// Checks purchase to see if it contains inactive products
        /// </summary>
        /// <param name="newPurchase">Purchase is the purchase to check.</param>
        /// <returns>string of product names from purchase that are inactive</returns>
        public async Task<string> CheckForInactiveProductsAsync(Purchase newPurchase)
        {
            string inactives = string.Empty;

            foreach (var lineItem in newPurchase.LineItems)
            {
                var product = await _productProvider.GetProductByIdAsync(lineItem.ProductId);
                if (!product.Active)
                {                    
                    inactives += (product.Name + " , " );
                }
            }
            if (inactives != string.Empty)
            {
                return inactives.Remove(inactives.Length -3);
            }
            else
            {
                return inactives;
            }
        }
    }
}
