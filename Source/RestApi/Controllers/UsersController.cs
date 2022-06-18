using AutoMapper;
using DDD.Application.Commands;
using DDD.Application.Contracts.Dtos;
using DDD.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    public readonly IMediator _mediator;
    public readonly IMapper _mapper;

    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetAllUsersQuery());

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetOne(int id)
    {
        var response = await _mediator.Send(new GetUserQuery() { Id = id });

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateUserRequest request)
    {

        var response = await _mediator.Send(_mapper.Map<CreateUserCommand>(request));

        return CreatedAtAction(nameof(GetOne), new { Id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateUserRequest request)
    {
        var command = _mapper.Map<UpdateUserCommand>(request);
        command.Id = id;
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}
