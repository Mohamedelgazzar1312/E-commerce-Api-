using Dtos.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.OrderServices;

namespace E_commerce.Controllers.OrderController
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;

        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<List<OrderDTO>>> GetAllOrders()
        {
            var Orders = await _OrderService.GetAllAsync();
            if (Orders == null)
            {
                return Ok(new List<OrderDTO>());
            }
            return Ok(Orders);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrderById(int id)
        {
            var Order = await _OrderService.GetByIdAsync(id);
            if (Order == null)
            {
                return NotFound();
            }
            return Ok(Order);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> CreateOrder(OrderDTO OrderDTO)
        {
            var createdOrder = await _OrderService.CreateAsync(OrderDTO);

            return Ok(createdOrder);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Update(int id, OrderDTO OrderDTO)
        {
            var existingDto = await _OrderService.GetByIdAsync(id);
            if (existingDto == null)
            {
                return NotFound();
            }
            await _OrderService.UpdateAsync(OrderDTO);
            return Ok("Updated Successfuly");
        }

        [HttpDelete("{id}")]
       [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _OrderService.DeleteAsync(id);
            return Ok("Deleted Successfuly");
        }
    }


}

