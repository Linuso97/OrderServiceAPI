using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderServiceAPI.Data;
using OrderServiceAPI.Models.Orders;
using OrderServiceAPI.Services.Orders;

namespace OrderServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest orderRequest)
        {
            try
            {
                var order = await _ordersService.CreateOrderAsync(orderRequest);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

       // GET: api/Orders
       [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _ordersService.GetOrdersAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order?>> GetOrder(int id)
        {
            var order = await _ordersService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _ordersService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            await _ordersService.DeleteOrderAsync(id);

            return NoContent();
        }
    }
}
