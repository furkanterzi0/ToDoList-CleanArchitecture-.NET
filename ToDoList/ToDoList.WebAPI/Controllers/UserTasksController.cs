using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoList.Application.Features.Commands;
using ToDoList.Application.Features.Queries;

namespace ToDoList.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTasksController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserTasksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllUserTaskQuery();
            return Ok(await mediator.Send(query));


        }
        //[Authorize(AuthenticationSchemes = "MyCookieAuth")]
        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUserTaskCommand command)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            command.UserID = int.Parse(userIdClaim); // userId'yi cookie'den al

            return Ok(await mediator.Send(command));
        }


        [Authorize(AuthenticationSchemes = "MyCookieAuth")]
        [HttpGet("my")]
        public async Task<IActionResult> GetUserTasks()
        {

            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim);

            var query = new GetTasksById(userId);
            return Ok(await mediator.Send(query));

        }

        [HttpPut("{id}/{state}")]
        public async Task<IActionResult> UpdateTaskState(int id, int state)
        {
            var command = new UpdateState(id, state);
            var result = await mediator.Send(command);

            if (result > 0)
                return Ok();
            else
                return BadRequest("Güncelleme başarısız.");
        }


    }
}
