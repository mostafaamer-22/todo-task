using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Features.ToDoItem.Command.AddToDoItem;
using ToDo.Application.Features.ToDoItem.Command.MakeToDoItemCompleted;
using ToDo.Application.Features.ToDoItem.Query;

namespace ToDo.Api.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : ApiController
    {
        public ToDoController(ISender sender) : base(sender)
        {
        }

        [HttpPost("AddToDoitem")]
        public async Task<IActionResult> AddItem([FromQuery] AddToDoItemCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return HandleResult(result);
        }

        [HttpGet("getallToDoItems")]
        public async Task<IActionResult> GetAllItems([FromQuery] GetToDoItemQuery query , CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return HandleResult(result);
        }


        [HttpPut("CompleteToDo")]
        public async Task<IActionResult> CompleteItem([FromQuery] MakeToDoItemCompletedCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return HandleResult(result);
        }
    }
}
