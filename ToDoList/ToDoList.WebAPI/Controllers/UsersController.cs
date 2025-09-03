using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoList.Application.Features.Commands;
using ToDoList.Application.Features.Queries;
using ToDoList.Infrastructure.Context;

namespace ToDoList.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllUserQuery();
            return Ok(await mediator.Send(query));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var user = await mediator.Send(command);
            if (user == null)
                return Unauthorized("Kullanıcı adı veya şifre hatalı.");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("MyCookieAuth", principal);

            // 🔽 JavaScript erişebilsin diye ekstra bir cookie yaz
            Response.Cookies.Append("userId", user.Id.ToString(), new CookieOptions
            {
                HttpOnly = false,
                Secure = true,
                SameSite = SameSiteMode.None
            });

            Response.Cookies.Append("username", user.Username, new CookieOptions
            {
                HttpOnly = false,
                Secure = true,
                SameSite = SameSiteMode.None
            });


            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUserCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
