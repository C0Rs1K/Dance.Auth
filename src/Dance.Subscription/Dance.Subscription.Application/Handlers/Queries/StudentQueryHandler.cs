using AutoMapper;
using Dance.Subscription.Application.Dtos.ResponseDto;
using Dance.Subscription.Application.Exceptions;
using Dance.Subscription.Application.Queries.Student;
using Dance.Subscription.Domain.Interfaces;
using MediatR;
using MongoDB.Bson;

namespace Dance.Subscription.Application.Handlers.Queries;

public class StudentQueryHandler(IStudentRepository studentRepository, IMapper mapper) : 
    IRequestHandler<GetStudentByIdQuery, StudentResponseDto>, 
    IRequestHandler<GetAllStudentsQuery, List<StudentResponseDto>>
{
    public async Task<StudentResponseDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var id = new ObjectId(request.Id);
        var student = await studentRepository.GetFirstAsync(x => x.Id == id, cancellationToken);
        NotFoundException.ThrowIfNull(student);

        return mapper.Map<StudentResponseDto>(student);
    }

    public async Task<List<StudentResponseDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await studentRepository.GetRangeAsync(x => true, cancellationToken);

        return mapper.Map<List<StudentResponseDto>>(students);
    }
}
