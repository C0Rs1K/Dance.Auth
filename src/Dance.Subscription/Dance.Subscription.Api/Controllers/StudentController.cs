using Dance.Subscription.Application.Commands.Student;
using Dance.Subscription.Application.Dtos.RequestDto;
using Dance.Subscription.Application.Queries.Student;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dance.Subscription.Api.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class StudentController(ISender sender) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudentById(string id)
    {
        var result = await sender.Send(new GetStudentByIdQuery(id));

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
        var result = await sender.Send(new GetAllStudentsQuery());

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromBody] StudentRequestDto studentRequestDto)
    {
        var result = await sender.Send(new CreateStudentCommand(studentRequestDto));

        return CreatedAtAction(nameof(GetStudentById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(string id, [FromBody] StudentRequestDto studentRequestDto)
    {
        var result = await sender.Send(new UpdateStudentCommand(id, studentRequestDto));

        return  Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(string id)
    {
        await sender.Send(new DeleteStudentCommand(id));

        return NoContent();
    }
}