using EStoreBackend.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrder createOrder);
        Task<object> GetAllOrder(string status);
        Task<object> GetAllOrderByUserId(string userName, string status);
    }
}
