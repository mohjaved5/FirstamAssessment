using SampleAPI.Entities;

namespace SampleAPI.Requests
{
    public interface ICreateOrderRequest
    {
        Task CreateOrderAsync(Order order);
        Task<ICollection<Order>> GetRecentOrdersAsync();

    }
}
