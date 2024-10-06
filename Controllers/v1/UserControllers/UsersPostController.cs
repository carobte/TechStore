using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.Config;
using TechStore.DTOs.Auth;
using TechStore.Models;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.UserControllers
{
    [ApiController]
    [Route("api/v1/users")]
    [Tags("users")]
    public class UsersPostController : UsersController
    {
        public UsersPostController(IUserRepository userRepository, Utilities utilities) : base(userRepository, utilities)
        {
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create user",
            Description = "Register user in database"
        )]
        [SwaggerResponse(201, "Created: User registered successfully")]
        [SwaggerResponse(400, "Bad request")]

        public async Task<IActionResult> Post(RegisterDTO newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userRepository.Create(newUser);
            return Created();
        }

        [HttpPost]
        [Route("login")]
        [SwaggerOperation(
            Summary = "Login user",
            Description = "Login user with email and password"
        )]
        [SwaggerResponse(200, "User logged in successfully")]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> Login(LoginDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _userRepository.Login(user);
            
            if (token == null)
            {
                return BadRequest("An error occurred, please try again");
            }
            
            if (token == "client")
            {
                return Unauthorized("Logged in. However, you don't have the needed permissions for certain endpoints");
            }
            
            else
            {
                return Ok($"Here's the token: {token}");
            }
        }
    }
}