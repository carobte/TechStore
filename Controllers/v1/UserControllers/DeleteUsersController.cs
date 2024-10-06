using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.Config;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.UserControllers
{
    [ApiController]
    [Route("api/v1/users")]
    [Tags("users")]
    public class DeleteUsersController : UsersController
    {
        public DeleteUsersController(IUserRepository userRepository, Utilities utilities) : base(userRepository, utilities)
        {
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Delete user",
        Description = "Delete user, using its Id")]
        [SwaggerResponse(204, "User deleted successfully")]

        public async Task<IActionResult> Delete(int id)
        {
            await _userRepository.Delete(id);
            return NoContent();
        }
    }

}