using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dance.Store.Application.UseCases.Student.GetAllStudents;

public class GetAllStudentsHandler(IStudentRepository studentRepository, IMapper mapper) : IRequestHandler<GetAllStudentsCommand, IEnumerable<StudentResponseDto>>
{
    public async Task<IEnumerable<StudentResponseDto>> Handle(GetAllStudentsCommand request, CancellationToken cancellationToken)
    {
        var students = studentRepository.GetRange(x => true, cancellationToken);
        return await mapper.ProjectTo<StudentResponseDto>(students).ToListAsync(cancellationToken);
    }
}