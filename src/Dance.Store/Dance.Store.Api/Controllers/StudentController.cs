using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.UseCases.Student.CreateStudent;
using Dance.Store.Application.UseCases.Student.DeleteStudent;
using Dance.Store.Application.UseCases.Student.GetAllStudents;
using Dance.Store.Application.UseCases.Student.GetStudentById;
using Dance.Store.Application.UseCases.Student.UpdateStudent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dance.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetStudentsAsync(CancellationToken cancellationToken)
        {
            return Ok(await sender.Send(new GetAllStudentsCommand(), cancellationToken));
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudentByIdAsync(Guid studentId, CancellationToken cancellationToken)
        {
            return Ok(await sender.Send(new GetStudentByIdCommand(studentId), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync([FromBody] StudentRequestDto studentRequestDto,
            CancellationToken cancellationToken)
        {
            return Ok(await sender.Send(new CreateStudentCommand(studentRequestDto), cancellationToken));

        }

        [HttpPut("{studentId}")]
        public async Task<IActionResult> UpdateStudentAsync(Guid studentId,
            [FromBody] StudentRequestDto studentRequestDto, CancellationToken cancellationToken)
        {
            await sender.Send(new UpdateStudentCommand(studentId, studentRequestDto), cancellationToken);
            return NoContent();
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudentAsync(Guid studentId, CancellationToken cancellationToken)
        {
            await sender.Send(new DeleteStudentCommand(studentId), cancellationToken);
            return NoContent();
        }
    }
}
