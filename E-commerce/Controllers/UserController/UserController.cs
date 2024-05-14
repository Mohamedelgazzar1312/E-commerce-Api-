using Dtos.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.UserServices;

namespace E_commerce.Controllers.UserController
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            if (users == null)
            {
                   return Ok(new List<UserDTO>()); 
            }
            return Ok(users);
        }


        [HttpGet("GetByUsername/{username}")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var user = await _userService.GetByUsernameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("{id}")]
        [Authorize (Roles ="Admin")]
        public async Task<ActionResult<UserDTO>> GetUserById(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

  

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(string id, UserDTO userDTO)
        {
            var existingDto = await _userService.GetByIdAsync(id);
            if (existingDto == null)
            {
                return NotFound();
            }
            await _userService.UpdateAsync(userDTO);
            return Ok("Updated Successfuly");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok("Deleted Successfuly");
        }
    }


}

