using Microsoft.AspNetCore.Mvc;
using SampleAPI.Entities;
using SampleAPI.Repositories;
using SampleAPI.Requests;

namespace SampleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ICreateOrderRequest _createOrderRequest;
        // Add more dependencies as needed.

        public OrdersController(ICreateOrderRequest createOrderRequest)
        {
            _createOrderRequest = createOrderRequest;
        }
 
        /// <summary>
        /// Get orders api
        /// </summary>
        /// <returns></returns>
        [HttpGet] // TODO: Change route, if needed.
        [ProducesResponseType(StatusCodes.Status200OK)] // TODO: Add all response types
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            return Ok(await _createOrderRequest.GetRecentOrdersAsync());
        }

        /// <summary>
        /// Create 
        /// </summary>
        /// <param name="order"></param>
        /// <returns><
        /// /returns>
        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] Order order)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _createOrderRequest.CreateOrderAsync(order);
            return Ok();
        }

    }
}
