using AutoMapper;
using Dance.Subscription.Application.Dtos.ResponseDto;
using Dance.Subscription.Application.Queries.Student;
using Dance.Subscription.Domain.Interfaces;
using MediatR;

namespace Dance.Subscription.Application.Handlers.Queries.Student;

public class GetAllStudentsHandler(IStudentRepository studentRepository, IMapper mapper) : IRequestHandler<GetAllStudentsQuery, List<StudentResponseDto>>
{
    public async Task<List<StudentResponseDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await studentRepository.GetRangeAsync(x => true, cancellationToken);

        return mapper.Map<List<StudentResponseDto>>(students);
    }
}