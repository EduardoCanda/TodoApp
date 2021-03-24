using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        /* private TodoHandler _handler;

         public TodoController(TodoHandler handler)
         {
             _handler = handler;
         }*/

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler handler
        )
        {
            command.User = "EduardoCanda";
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}