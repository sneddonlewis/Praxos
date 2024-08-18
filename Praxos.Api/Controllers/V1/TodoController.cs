using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Praxos.Api.Controllers.Mapping;
using Praxos.Api.Controllers.V1.ViewModels;
using Praxos.Application.Contracts.Persistence;
using Praxos.Application.Models;

namespace Praxos.Api.Controllers.V1;

[ApiController]
[Route("[controller]")]
public class TodoController(ITodoRepo todoRepo) : ControllerBase
{
    private readonly IMapper _mapper = ControllerMapper.Mapper;
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> GetAll()
    {
        return Ok(await todoRepo.All());
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Todo>> GetById(string id)
    {
        var result = (await todoRepo.FindById(id)).FirstOrDefault();
        return result is null ? NotFound() : Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<Todo>> Create(TodoCreateVm todo)
    {
        return Ok(await todoRepo.Create(_mapper.Map<Todo>(todo)));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        return await todoRepo.Delete(id) ? Ok() : NotFound();
    }
}