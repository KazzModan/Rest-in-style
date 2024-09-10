using Microsoft.AspNetCore.Mvc;
using R.I.S.BLL.DTO;
using R.I.S.BLL.Services.Abstraction;

namespace R.I.S.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _UserService;
        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var Users = await _UserService.GetAllUsers().ConfigureAwait(false);
                return Ok(Users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByID(Guid id)
        {
            try
            {
                var User = await _UserService.GetUserById(id).ConfigureAwait(false);
                return Ok(User);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostUsert(UserDTO User)
        {
            try
            {
                await _UserService.AddUser(User).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPut]
        public async Task<IActionResult> PutUser(UserDTO User)
        {
            try
            {
                await _UserService.UpdateUser(User).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _UserService.DeleteUser(id).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
