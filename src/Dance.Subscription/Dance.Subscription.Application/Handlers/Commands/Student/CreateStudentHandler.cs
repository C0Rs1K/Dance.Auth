using AutoMapper;
using Dance.Subscription.Application.Commands.Student;
using Dance.Subscription.Application.Dtos.ResponseDto;
using Dance.Subscription.Domain.Interfaces;
using MediatR;

namespace Dance.Subscription.Application.Handlers.Commands.Student;

public class CreateStudentHandler(IStudentRepository studentRepository, IMapper mapper) : IRequestHandler<CreateStudentCommand, StudentResponseDto>
{
    public async Task<StudentResponseDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = mapper.Map<Domain.Entities.Student>(request.StudentRequestDto);
        await studentRepository.CreateAsync(student, cancellationToken);

        return mapper.Map<StudentResponseDto>(student);
    }
}