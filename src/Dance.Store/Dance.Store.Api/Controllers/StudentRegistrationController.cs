using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.UseCases.StudentRegistration.CreateStudentRegistration;
using Dance.Store.Application.UseCases.StudentRegistration.DeleteStudentRegistration;
using Dance.Store.Application.UseCases.StudentRegistration.GetAllStudentRegistrations;
using Dance.Store.Application.UseCases.StudentRegistration.GetStudentRegistrationById;
using Dance.Store.Application.UseCases.StudentRegistration.UpdateStudentRegistration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dance.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentRegistrationController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetStudentRegistrationsAsync(CancellationToken cancellationToken)
        {
            return Ok(await sender.Send(new GetAllStudentRegistrationsCommand(), cancellationToken));
        }

        [HttpGet("{studentRegistrationId}")]
        public async Task<IActionResult> GetStudentRegistrationByIdAsync(Guid studentRegistrationId, CancellationToken cancellationToken)
        {
            return Ok(await sender.Send(new GetStudentRegistrationByIdCommand(studentRegistrationId), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentRegistrationAsync([FromBody] StudentRegistrationRequestDto studentRegistrationRequestDto,
            CancellationToken cancellationToken)
        {
            return Ok(await sender.Send(new CreateStudentRegistrationCommand(studentRegistrationRequestDto),
                cancellationToken));
        }

        [HttpPut("{studentRegistrationId}")]
        public async Task<IActionResult> UpdateStudentRegistrationAsync(Guid studentRegistrationId,
            [FromBody] StudentRegistrationRequestDto studentRegistrationRequestDto, CancellationToken cancellationToken)
        {
            await sender.Send(new UpdateStudentRegistrationCommand(studentRegistrationId, studentRegistrationRequestDto), cancellationToken);
            return NoContent();
        }

        [HttpDelete("{studentRegistrationId}")]
        public async Task<IActionResult> DeleteStudentRegistrationAsync(Guid studentRegistrationId, CancellationToken cancellationToken)
        {
            await sender.Send(new DeleteStudentRegistrationCommand(studentRegistrationId), cancellationToken);
            return NoContent();
        }
    }
}
