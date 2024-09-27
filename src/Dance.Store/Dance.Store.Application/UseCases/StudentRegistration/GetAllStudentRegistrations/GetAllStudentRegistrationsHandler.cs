using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dance.Store.Application.UseCases.StudentRegistration.GetAllStudentRegistrations;

public class GetAllStudentRegistrationsHandler(IStudentRegistrationRepository studentRegistrationRepository, IMapper mapper) : IRequestHandler<GetAllStudentRegistrationsCommand, IEnumerable<StudentRegistrationResponseDto>>
{
    public async Task<IEnumerable<StudentRegistrationResponseDto>> Handle(GetAllStudentRegistrationsCommand request, CancellationToken cancellationToken)
    {
        var studentRegistrations = studentRegistrationRepository.GetRange(x => true, cancellationToken);
        return await mapper.ProjectTo<StudentRegistrationResponseDto>(studentRegistrations)
            .ToListAsync(cancellationToken);
    }
}