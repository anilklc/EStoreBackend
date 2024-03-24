namespace EStoreBackend.Application.Features.Queries.Policy.GetByIdPolicy
{
    public class GetByIdPolicyQueryResponse
    {
        public string Id { get; set; }
        public string PolicyName { get; set; }
        public string PolicyDescription { get; set; }
        public string PolicyIcon { get; set; }
        public string PolicyTabHref { get; set; }
    }
}