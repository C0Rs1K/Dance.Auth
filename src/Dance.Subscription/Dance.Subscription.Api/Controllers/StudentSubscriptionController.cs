using Dance.Subscription.Application.Commands.StudentSubscription;
using Dance.Subscription.Application.Dtos.RequestDto;
using Dance.Subscription.Application.Queries.StudentSubscription;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dance.Subscription.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentSubscriptionController(ISender sender) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await sender.Send(new GetStudentSubscriptionByIdQuery(id));

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await sender.Send(new GetAllStudentSubscriptionsQuery());

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StudentSubscriptionRequestDto studentSubscriptionRequestDto)
    {
        var result = await sender.Send(new CreateStudentSubscriptionCommand(studentSubscriptionRequestDto));

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] StudentSubscriptionRequestDto studentSubscriptionRequestDto)
    {
        var result = await sender.Send(new UpdateStudentSubscriptionCommand(id, studentSubscriptionRequestDto));

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await sender.Send(new DeleteStudentSubscriptionCommand(id));

        return NoContent();
    }
}
