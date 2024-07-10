using MediatR;

namespace EStoreBackend.Application.Features.Commands.Address.UpdateAddress
{
    public class UpdateAddressCommandRequest : IRequest<UpdateAddressCommandResponse>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string AddressTitle { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Detail { get; set; }
    }
}