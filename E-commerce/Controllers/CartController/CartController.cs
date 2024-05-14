using Dtos.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CartServices;

namespace E_commerce.Controllers.CartController
{
    [ApiController]
    [Route("api/[controller]")] 
    public class CartController : ControllerBase
    {
        private readonly ICartService _CartService;

        public CartController(ICartService CartService)
        {
            _CartService = CartService;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<List<CartDTO>>> GetAllCarts()
        {
            var Carts = await _CartService.GetAllAsync();
            if (Carts == null)
            {
                return Ok(new List<CartDTO>());
            }
            return Ok(Carts);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<CartDTO>> GetCartById(int id)
        {
            var Cart = await _CartService.GetByIdAsync(id);
            if (Cart == null)
            {
                return NotFound();
            }
            return Ok(Cart);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<CartDTO>> CreateCart(CartDTO CartDTO)
        {
            var createdCart = await _CartService.CreateAsync(CartDTO);

            return Ok(createdCart);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Update(int id, CartDTO CartDTO)
        {
            var existingDto = await _CartService.GetByIdAsync(id);
            if (existingDto == null)
            { 
                return NotFound();
            }
            await _CartService.UpdateAsync(CartDTO);
            return Ok("Updated Successfuly");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            await _CartService.DeleteAsync(id);
            return Ok("Deleted Successfuly");
        }
    }


}

