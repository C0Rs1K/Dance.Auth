using Dance.Subscription.Application.Commands.Subscription;
using Dance.Subscription.Application.Dtos.RequestDto;
using Dance.Subscription.Application.Queries.Subscription;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dance.Subscription.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionController(ISender mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSubscriptionById(string id)
    {
        var result = await mediator.Send(new GetSubscriptionByIdQuery(id));

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSubscriptions()
    {
        var result = await mediator.Send(new GetAllSubscriptionsQuery());

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubscription([FromBody] SubscriptionRequestDto subscriptionRequestDto)
    {
        var result = await mediator.Send(new CreateSubscriptionCommand(subscriptionRequestDto));

        return CreatedAtAction(nameof(GetSubscriptionById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSubscription(string id, [FromBody] SubscriptionRequestDto subscriptionRequestDto)
    {
        var result = await mediator.Send(new UpdateSubscriptionCommand(id, subscriptionRequestDto));

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubscription(string id)
    {
        await mediator.Send(new DeleteSubscriptionCommand(id));

        return NoContent();
    }
}
