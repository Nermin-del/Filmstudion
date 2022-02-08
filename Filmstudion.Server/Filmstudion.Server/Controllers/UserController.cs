using AutoMapper;
using Filmstudion.Business.DTOs.User;
using Filmstudion.Business.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Filmstudion.Server.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public UserController(IMapper mapper, IUserService userService)
        {
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var userList = userService.GetUsers();
            var userDto = new List<UserDto>();

            foreach(var user in userList)
            {
                userDto.Add(mapper.Map<UserDto>(user));
            }
            return Ok(userDto);
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserRegisterDto model)
        {
            var user = userService.Authenticate(model.Username, model.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Fel användarnamn eller lösenord" });
            }
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterDto model)
        {
            bool ifUsernameUnique = userService.IsUniqueName(model.Username);
            if (!ifUsernameUnique)
            {
                return BadRequest(new { message = "Användarnamnet finns redan!" });
            }
            var user = userService.Register(model.Username, model.Password, model.IsAdmin);

            if (user == null)
            {
                return BadRequest(new { message = "Något gick fel med registreringen" });
            }

            return Ok(model);
        }
    }
}
