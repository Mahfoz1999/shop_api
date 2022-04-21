using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_api.IRepository;
using shop_api.Models;

namespace shop_api.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _IUser;
        public UserController(IUserRepository user)
        {
            _IUser = user;
        }
        [HttpGet("getAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> getAllUsers()
        {
            return await Task.FromResult(_IUser.GetAllUsers());
        }
        [HttpGet("getUser/{Id}")]
        public async Task<ActionResult<User>> getUser(Guid Id)
        {
            var user = await Task.FromResult(_IUser.GetUserDetails(Id));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost("addUser")]
        public async Task<ActionResult<User>> addUser(User user)
        {
            _IUser.AddUser(user);
            return await Task.FromResult(user);
        }
        [HttpPut("editUser/{Id}")]
        public async Task<ActionResult<User>> editUser(Guid Id, User user)
        {
            if (Id != user.UserId)
            {
                return BadRequest();
            }
            try
            {
                _IUser.UpdateUser(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_IUser.CheckUser(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(user);
        }
        [HttpDelete("deleteUser/{Id}")]
        public async Task<ActionResult<User>> Delete(Guid Id)
        {
            var user = _IUser.DeleteUser(Id);
            return await Task.FromResult(user);
        }
    }
}
