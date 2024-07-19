namespace EStoreBackend.Application.Features.Queries.User.GetUserByUserId
{
    public class GetUserByUserIdQueryResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}