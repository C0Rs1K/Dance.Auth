using AutoMapper;
using Dance.Subscription.Application.Commands.Student;
using Dance.Subscription.Application.Dtos.ResponseDto;
using Dance.Subscription.Application.Exceptions;
using Dance.Subscription.Domain.Entities;
using Dance.Subscription.Domain.Interfaces;
using MediatR;
using MongoDB.Bson;

namespace Dance.Subscription.Application.Handlers.Commands;

public class StudentCommandHandler(IStudentRepository studentRepository, IMapper mapper) :
    IRequestHandler<CreateStudentCommand, StudentResponseDto>,
    IRequestHandler<UpdateStudentCommand, StudentResponseDto>,
    IRequestHandler<DeleteStudentCommand>
{
    public async Task<StudentResponseDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = mapper.Map<Student>(request.StudentRequestDto);
        await studentRepository.CreateAsync(student, cancellationToken);

        return mapper.Map<StudentResponseDto>(student);
    }

    public async Task<StudentResponseDto> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await studentRepository.GetFirstAsync(x => x.Id == new ObjectId(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(student);
        mapper.Map(request.StudentRequestDto, student);
        await studentRepository.UpdateAsync(request.Id, student, cancellationToken);

        return mapper.Map<StudentResponseDto>(student);
    }

    public async Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await studentRepository.GetFirstAsync(x => x.Id == new ObjectId(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(student);
        await studentRepository.DeleteAsync(request.Id, cancellationToken); 
    }
}
