using System;

namespace Catalyte.Apparel.DTOs.Reviews
{
    public class ReviewsDTO
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        public string Title { get; set; }

        public string ReviewsDescription { get; set; }

        public string Email { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
