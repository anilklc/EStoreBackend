using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.DTOs.ReviewImage
{
    public class ListReviewWithReviewImage
    {
        public string Id { get; set; }
        public string ImagePath { get; set; }
        public string ReviewId { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewComment { get; set; }
    }
}
