using SampleAPI.Entities;
using SampleAPI.Repositories;

namespace SampleAPI.Requests
{
    public class CreateOrderRequest : ICreateOrderRequest
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderRequest(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CreateOrderAsync(Order order)
        {
            order.Id = Guid.NewGuid();
            order.EntryDate = DateTime.UtcNow;
            await _orderRepository.AddNewOrderAsync(order);
        }

        public async Task<ICollection<Order>> GetRecentOrdersAsync()
        {
            return await _orderRepository.GetRecentOrdersAsync();
        }
    }
}
