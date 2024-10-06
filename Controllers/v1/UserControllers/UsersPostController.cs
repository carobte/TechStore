using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Post(User newUser){                      
            await _userRepository.Create(newUser);
            return CreatedAtAction(nameof(Post), new { id = newUser.Id }, newUser);
        }

    }
}