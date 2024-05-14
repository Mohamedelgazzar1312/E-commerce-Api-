using Dtos.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.OrderDetailsServices;

namespace E_commerce.Controllers.OrderDetailsController
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _OrderDetailsService;

        public OrderDetailsController(IOrderDetailService OrderDetailsService)
        {
            _OrderDetailsService = OrderDetailsService;
        }

        [HttpGet]
       [Authorize(Roles = "User")]
        public async Task<ActionResult<List<OrderDetailDTO>>> GetAllOrderDetailss()
        {
            var OrderDetailss = await _OrderDetailsService.GetAllAsync();
            if (OrderDetailss == null)
            {
                return Ok(new List<OrderDetailDTO>());
            }
            return Ok(OrderDetailss);
        }
        [HttpGet("{id}")]
      [Authorize(Roles = "User")]
        public async Task<ActionResult<OrderDetailDTO>> GetOrderDetailsById(int id)
        {
            var OrderDetails = await _OrderDetailsService.GetByIdAsync(id);
            if (OrderDetails == null)
            {
                return NotFound();
            }
            return Ok(OrderDetails);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<OrderDetailDTO>> CreateOrderDetails(OrderDetailDTO OrderDetailsDTO)
        {
            var createdOrderDetails = await _OrderDetailsService.CreateAsync(OrderDetailsDTO);

            return Ok(createdOrderDetails);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Update(int id, OrderDetailDTO OrderDetailsDTO)
        {
            var existingDto = await _OrderDetailsService.GetByIdAsync(id);
            if (existingDto == null)
            {
                return NotFound();
            }
            await _OrderDetailsService.UpdateAsync(OrderDetailsDTO);
            return Ok("Updated Successfuly");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteOrderDetails(int id)
        {
            await _OrderDetailsService.DeleteAsync(id);
            return Ok("Deleted Successfuly");
        }
    }


}

