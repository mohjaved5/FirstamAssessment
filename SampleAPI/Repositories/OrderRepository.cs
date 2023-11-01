using Microsoft.EntityFrameworkCore;
using SampleAPI.Entities;
using SampleAPI.Requests;

namespace SampleAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SampleApiDbContext _sampleApiDbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sampleApiDbContext"></param>
        public OrderRepository(SampleApiDbContext sampleApiDbContext)
        {
            _sampleApiDbContext = sampleApiDbContext;
        }

        /// <summary>
        /// Add new order
        /// </summary>
        /// <param name="order"></param>
        public async Task AddNewOrderAsync(Order order)
        {
           await _sampleApiDbContext.Orders.AddAsync(order);
           await _sampleApiDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get recent orders
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Order>> GetRecentOrdersAsync()
        {
            var recentOrder = _sampleApiDbContext.Orders.Where(x => x.EntryDate >= DateTime.UtcNow.AddDays(-1) && !x.IsDeleted);
            if (recentOrder != null)
            {
                return await recentOrder.ToListAsync();
            }
            return new List<Order>();
        }
    }
}
