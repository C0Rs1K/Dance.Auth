using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.UseCases.DanceClass.CreateDanceClass;
using Dance.Store.Application.UseCases.DanceClass.DeleteDanceClass;
using Dance.Store.Application.UseCases.DanceClass.GetAllDanceClasses;
using Dance.Store.Application.UseCases.DanceClass.GetDanceClassById;
using Dance.Store.Application.UseCases.DanceClass.UpdateDanceClass;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dance.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanceClassController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetDanceClassesAsync(CancellationToken cancellationToken)
        {
            return Ok(await sender.Send(new GetAllDanceClassesCommand(), cancellationToken));
        }

        [HttpGet("{danceClassId}")]
        public async Task<IActionResult> GetDanceClassByIdAsync(Guid danceClassId, CancellationToken cancellationToken)
        {
            return Ok(await sender.Send(new GetDanceClassByIdCommand(danceClassId), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDanceClassAsync([FromBody] DanceClassRequestDto danceClassRequestDto,
            CancellationToken cancellationToken)
        {
            return Ok(await sender.Send(new CreateDanceClassCommand(danceClassRequestDto), cancellationToken));

        }

        [HttpPut("{danceClassId}")]
        public async Task<IActionResult> UpdateDanceClassAsync(Guid danceClassId,
            [FromBody] DanceClassRequestDto danceClassRequestDto, CancellationToken cancellationToken)
        {
            await sender.Send(new UpdateDanceClassCommand(danceClassId, danceClassRequestDto), cancellationToken);
            return NoContent();
        }

        [HttpDelete("{danceClassId}")]
        public async Task<IActionResult> DeleteDanceClassAsync(Guid danceClassId, CancellationToken cancellationToken)
        {
            await sender.Send(new DeleteDanceClassCommand(danceClassId), cancellationToken);
            return NoContent();
        }
    }
}
