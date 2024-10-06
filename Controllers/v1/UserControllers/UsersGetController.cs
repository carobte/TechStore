using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.Config;
using TechStore.DTOs.User;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.UserControllers
{
    [ApiController]
    [Route("api/v1/users")]
    [Tags("users")]
    public class UsersGetController : UsersController
    {
        public UsersGetController(IUserRepository userRepository, Utilities utilities) : base(userRepository, utilities)
        {
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get users",
            Description = "Returns all the registered users (admins, employees and clients)"
        )]
        [SwaggerResponse(200, "Ok: Returns all the registered users (admins, employees and clients)")]
        [SwaggerResponse(204, "No Content: There are not users in the database")]

        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.Get();

            if (users == null || !users.Any())
            {
                return NoContent();
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get user by id",
            Description = "Returns the specific user information"
        )]
        [SwaggerResponse(200, "Ok: Returns the user information")]
        [SwaggerResponse(404, "Not found: There is not user with that id")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}