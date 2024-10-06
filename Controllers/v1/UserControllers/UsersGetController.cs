using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.Get();
            
            if (users == null || !users.Any())
            {
                return NoContent();
            }
            
/*             foreach (var user in users)
            {
                new UserDTO {
                    Name = user.Name,
                    Address = user.Address,
                    Telephone = user.Telephone,
                    Email = user.Email,
                    RolName = user.Rol.Name
                };
            } */

            return Ok(users);
        }   
    }
}