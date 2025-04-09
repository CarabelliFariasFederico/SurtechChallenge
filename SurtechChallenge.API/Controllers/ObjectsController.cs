using MediatR;
using Microsoft.AspNetCore.Mvc;
using SurtechChallenge.Application.Features.Objects.Commands;
using SurtechChallenge.Application.Features.Objects.Queries;
using SurtechChallenge.Domain.Entities;

namespace SurtechChallenge.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ObjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ObjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApiObject>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllObjectsQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ApiObject>> Create([FromBody] CreateObjectCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiObject>> GetById(string id)
    {
        var result = await _mediator.Send(new GetObjectByIdQuery { Id = id });
        if (result == null)
            return NotFound($"Object with ID {id} not found");

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiObject>> Update(string id, [FromBody] UpdateObjectCommand command)
    {
        if (id != command.Id) return BadRequest("ID in URL and body must match.");

        var result = await _mediator.Send(command);
        if (result == null) return NotFound();

        return Ok(result);
    }

}
