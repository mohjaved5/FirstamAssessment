using SampleAPI.Entities;
using SampleAPI.Requests;

namespace SampleAPI.Repositories
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Get list of recent orders
        /// </summary>
        /// <returns></returns>
        Task<ICollection<Order>> GetRecentOrdersAsync();

        /// <summary>
        /// Add a new order
        /// </summary>
        /// <param name="order"></param>
        Task  AddNewOrderAsync(Order order);
    }
}
