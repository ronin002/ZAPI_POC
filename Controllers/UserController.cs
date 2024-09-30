using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZurichAPI.Model.Dto;
using ZurichAPI.Model.Entity;
using ZurichAPI.Repository;
using ZurichAPI.Utils;

namespace ZurichAPI.Controllers
{
    [ApiController]
    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;


        public UserController(ILogger<UserController> logger,
                                IUserRepository userRepository,
                                IRoleRepository roleRepository) : base( userRepository,
                                                                        roleRepository)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet("api/v1/user/")]
        public IActionResult GetTest() 
        {
            return Ok("Teste");
        }

        [HttpPost("api/v1/user/")]
        public IActionResult CreateUser([FromBody] CreateUserDto userCreateModel)
        {
            var erros = new List<string>();

            if (userCreateModel == null)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err UCXE7001 invalid data"
                });


            var user = new UserModel();
            user.Id = Guid.NewGuid();
            user.Email = userCreateModel.Email;
            user.Name = userCreateModel.Name;
            //user.CompanyId = user.Id;
            user.Password = userCreateModel.Password;


            if (!UtilsSecurity.ValidMail(user.Email))
            {
                erros.Add("Err UCXE7002 invalid data");
            }
            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrWhiteSpace(user.Name) || user.Name.Length < 3)
            {
                erros.Add("Err UCXE7003a invalid data");
            }
            if (string.IsNullOrEmpty(user.Password) || string.IsNullOrWhiteSpace(user.Password) || user.Password.Length < 3)
            {
                erros.Add("Err UCXE7003b invalid data");
            }

            if (erros.Count > 0)
            {
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Errors = erros
                });
            }

            user.Password = UtilsSecurity.HashPassword(user.Email, user.Password);

            var bOk = _userRepository.Save(user);

            if (bOk)
            {
                user.Password = "";
                return Ok(user); //RedirectToPage("dashboard.cshtml");

            }
            else
            {
                //erros.Add("User already exists");
                return BadRequest("User already exists");
            }
        }




        [HttpGet("api/v1/user/GetUserById")]

        public IActionResult GetUser([FromRoute] string id)
        {
            var erros = new List<string>();

            try
            {
                var user = new UserModel();
                user = _userRepository.GetById(Guid.Parse(id));
                return Ok(user);
            }
            catch (Exception ex)
            {

                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err UXG7011 Server Error"
                });
            }

        }

        [HttpGet("api/v1/user/GetUsers")]
        public IActionResult GetUsers()
        {
            var erros = new List<string>();

            try
            {
              
                var user = new UserModel();
                List<UserAndRole> users = _userRepository.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {

                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err UXG7011 Server Error"
                });
            }

        }

        [HttpDelete("api/v1/user/DeleteUser")]

        public IActionResult DeleteUser([FromRoute] string id)
        {
            var erros = new List<string>();

            try
            {
                var user = new UserModel();
                user = _userRepository.GetById(Guid.Parse(id));
                if (user == null)
                {
                    return BadRequest(new ErrorDto
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Error = "Err UXG7012 User not found"
                    });
                }
                //_userRepository.Delete(user);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err UXG7011 Server Error"
                });
            }

        }

        [HttpPut("api/v1/user/UpdateUser")]
        public IActionResult UpdateUser([FromBody] UserModel user)
        {
            var erros = new List<string>();

            if (user == null)
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err UCXE7001 invalid data"
                });

            if (!UtilsSecurity.ValidMail(user.Email))
            {
                erros.Add("Err UCXE7002 invalid data");
            }
            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrWhiteSpace(user.Name) || user.Name.Length < 3)
            {
                erros.Add("Err UCXE7003a invalid data");
            }
            if (string.IsNullOrEmpty(user.Password) || string.IsNullOrWhiteSpace(user.Password) || user.Password.Length < 3)
            {
                erros.Add("Err UCXE7003b invalid data");
            }

            if (erros.Count > 0)
            {
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Errors = erros
                });
            }

            user.Password = UtilsSecurity.HashPassword(user.Email, user.Password);

            var bOk = _userRepository.Update(user);

            if (bOk)
            {
                user.Password = "";
                return Ok(user); //RedirectToPage("dashboard.cshtml");

            }
            else
            {
                //erros.Add("User already exists");
                return BadRequest("User already exists");
            }
        }
    }
}
