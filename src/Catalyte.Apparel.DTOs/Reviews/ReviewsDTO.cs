using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Apparel.DTOs.Reviews
{
    public class ReviewsDTO
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        public string Title { get; set; }

        public string ReviewsDescription { get; set; }

        public string Email { get; set; }
}
}
