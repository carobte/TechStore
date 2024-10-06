using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStore.Config;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.UserControllers
{
    [ApiController]
    [Route("api/v1/users")]

    public class UsersController : ControllerBase
    {
        protected readonly IUserRepository _userRepository;
        protected readonly Utilities _utilities;
        public UsersController(IUserRepository userRepository, Utilities utilities)
        {
            _userRepository = userRepository;
            _utilities = utilities;
        }
    }
}