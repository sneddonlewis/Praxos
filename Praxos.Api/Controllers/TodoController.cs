using Microsoft.AspNetCore.Mvc;
using Praxos.Application.Contracts.Persistence;
using Praxos.Application.Models;

namespace Praxos.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController(ITodoRepo todoRepo) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> Get()
    {
        return Ok(await todoRepo.All());
    }
    
    [HttpPost]
    public async Task<ActionResult<Todo>> Create(TodoCreateVm todo)
    {
        return Ok(await todoRepo.Create(new Todo{ Id = todo.Item }));
    }

    public class TodoCreateVm
    {
        public string Item { get; set; }
    }
}