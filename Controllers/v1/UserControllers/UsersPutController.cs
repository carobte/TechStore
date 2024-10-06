using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.Config;
using TechStore.DTOs.Auth;
using TechStore.DTOs.User;
using TechStore.Models;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.UserControllers
{
    [ApiController]
    [Route("api/v1/users")]
    [Tags("users")]
    public class UsersPutController : UsersController
    {
        public UsersPutController(IUserRepository userRepository, Utilities utilities) : base(userRepository, utilities)
        {
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update user",
            Description = "Update user, finding it by Id and putting the newInfo"
        )]
        [SwaggerResponse(200, "User updated")]
        [SwaggerResponse(400, "Bad request, please try again")]

        public async Task<IActionResult> Update(int id, UserDTO newUserInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userRepository.Update(id, newUserInfo);
            return Ok("User updated");
        }
    }
}