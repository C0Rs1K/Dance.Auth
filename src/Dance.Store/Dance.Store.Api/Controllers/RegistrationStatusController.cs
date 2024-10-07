using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.UseCases.RegistrationStatus.CreateRegistrationStatus;
using Dance.Store.Application.UseCases.RegistrationStatus.DeleteRegistrationStatus;
using Dance.Store.Application.UseCases.RegistrationStatus.GetAllRegistrationStatuses;
using Dance.Store.Application.UseCases.RegistrationStatus.GetRegistrationStatusById;
using Dance.Store.Application.UseCases.RegistrationStatus.UpdateRegistrationStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dance.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationStatusController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRegistrationStatusesAsync(CancellationToken cancellationToken)
        {
            return Ok(await sender.Send(new GetAllRegistrationStatusesCommand(), cancellationToken));
        }

        [HttpGet("{registrationStatusId}")]
        public async Task<IActionResult> GetRegistrationStatusByIdAsync(Guid registrationStatusId, CancellationToken cancellationToken)
        {
            return Ok(await sender.Send(new GetRegistrationStatusByIdCommand(registrationStatusId), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegistrationStatusAsync([FromBody] RegistrationStatusRequestDto registrationStatusRequestDto,
            CancellationToken cancellationToken)
        {
            return Ok(await sender.Send(new CreateRegistrationStatusCommand(registrationStatusRequestDto),
                cancellationToken));

        }

        [HttpPut("{registrationStatusId}")]
        public async Task<IActionResult> UpdateRegistrationStatusAsync(Guid registrationStatusId,
            [FromBody] RegistrationStatusRequestDto registrationStatusRequestDto, CancellationToken cancellationToken)
        {
            await sender.Send(new UpdateRegistrationStatusCommand(registrationStatusId, registrationStatusRequestDto), cancellationToken);

            return NoContent();
        }

        [HttpDelete("{registrationStatusId}")]
        public async Task<IActionResult> DeleteRegistrationStatusAsync(Guid registrationStatusId, CancellationToken cancellationToken)
        {
            await sender.Send(new DeleteRegistrationStatusCommand(registrationStatusId), cancellationToken);

            return NoContent();
        }
    }
}
