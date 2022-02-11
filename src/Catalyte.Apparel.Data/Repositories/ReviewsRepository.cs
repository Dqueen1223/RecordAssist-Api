﻿using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Catalyte.Apparel.Data.Repositories
/// <summary>
/// This class handles methods for making requests to the reviews repository.
/// </summary>
{
    public class ReviewsRepository : IReviewsRepository
    {
        private readonly IApparelCtx _ctx;

        public ReviewsRepository(IApparelCtx ctx)
        {
            _ctx = ctx;
        }

        public async Task<Review> GetReviewByIdAsync(int reviewId)
        {
            return await _ctx.Reviews.FindAsync(reviewId);
        }
        public async Task<Review> UpdateReviewAsync(Review review)
        {
            review.DateModified = DateTime.Now;
            _ctx.Reviews.Update(review);
            await _ctx.SaveChangesAsync();

            return review;
        }
        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await _ctx.Reviews.ToListAsync();
        }

    }

}
