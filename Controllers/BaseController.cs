using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ZurichAPI.Repository;

namespace ZurichAPI.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly IUserRepository _userRepository;
        protected readonly IRoleRepository _roleRepository;

        public BaseController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
    }
}
