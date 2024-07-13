using EStoreBackend.Application.DTOs;
using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Application.Interfaces.Services;
using EStoreBackend.Domain.Entities;
using System.Threading.Tasks;

namespace EStoreBackend.Persistence.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderDetailReadRepository _orderDetailReadRepository;
        private readonly IOrderDetailWriteRepository _orderDetailWriteRepository;
        private readonly IUserService _userService;

        public OrderService(
            IOrderReadRepository orderReadRepository,
            IOrderWriteRepository orderWriteRepository,
            IOrderDetailReadRepository orderDetailReadRepository,
            IOrderDetailWriteRepository orderDetailWriteRepository,
            IUserService userService)
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _orderDetailReadRepository = orderDetailReadRepository;
            _orderDetailWriteRepository = orderDetailWriteRepository;
            _userService = userService;
        }

        public async Task CreateOrderAsync(CreateOrder createOrder)
        {

            var user = await _userService.GetUserByUsernameAsync(createOrder.UserName);

            var order = new Order
            {
                UserId = user.Id,
                TotalPrice = createOrder.TotalPrice,
                OrderStatus = createOrder.OrderStatus,
                AddressId = createOrder.AddressId,
            };

            await _orderWriteRepository.AddAsync(order);
            await _orderWriteRepository.SaveAsync();

            foreach (var detail in createOrder.OrderDetails)
            {
                var orderDetail = new OrderDetail
                {
                    Order = order,
                    ProductAmount = detail.ProductAmount,
                    ProductId = detail.ProductId,
                    ProductName = detail.ProductName,
                    ProductPrice = detail.ProductPrice,
                    ProductTotalPrice = detail.ProductTotalPrice,
                };
                await _orderDetailWriteRepository.AddAsync(orderDetail);
            }

            await _orderDetailWriteRepository.SaveAsync();
        }

        public async Task<object> GetAllOrder(string status)
        {
            var orders = string.IsNullOrEmpty(status) ? _orderReadRepository.GetAll().ToList() : 
                _orderReadRepository.GetWhere(o => o.OrderStatus == status).ToList();
            return orders;
        }
        public async Task<object> GetAllOrderByUserId(string userName,string status)
        {
            var user = await _userService.GetUserByUsernameAsync(userName);
            var orders = string.IsNullOrEmpty(status) ? _orderReadRepository.GetWhere(u=>u.UserId == user.Id).ToList() :
                _orderReadRepository.GetWhere(o => o.OrderStatus == status && o.UserId == user.Id).ToList();
            return orders;
        }

    }
}
