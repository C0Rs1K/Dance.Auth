using AutoMapper;
using Dance.Subscription.Application.Commands.Student;
using Dance.Subscription.Application.Dtos.ResponseDto;
using Dance.Subscription.Application.Exceptions;
using Dance.Subscription.Domain.Interfaces;
using MediatR;
using MongoDB.Bson;

namespace Dance.Subscription.Application.Handlers.Commands.Student;

public class UpdateStudentHandler(IStudentRepository studentRepository, IMapper mapper) : IRequestHandler<UpdateStudentCommand, StudentResponseDto>
{
    public async Task<StudentResponseDto> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await studentRepository.GetFirstAsync(x => x.Id == new ObjectId(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(student);
        mapper.Map(request.StudentRequestDto, student);
        await studentRepository.UpdateAsync(request.Id, student, cancellationToken);

        return mapper.Map<StudentResponseDto>(student);
    }
}