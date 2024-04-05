namespace EStoreBackend.Application.Features.Queries.Review.GetByIdReview
{
    public class GetByIdReviewQueryResponse
    {
        public string Id { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewComment { get; set; }
    }
}