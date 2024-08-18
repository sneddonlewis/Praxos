using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Praxos.Api.Controllers.ViewModels;
using Praxos.Api.Controllers.ViewModels.Mapping;
using Praxos.Application.Contracts.Persistence;
using Praxos.Application.Models;

namespace Praxos.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController(ITodoRepo todoRepo) : ControllerBase
{
    private readonly IMapper _mapper = ControllerMapper.Mapper;
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> Get()
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
}