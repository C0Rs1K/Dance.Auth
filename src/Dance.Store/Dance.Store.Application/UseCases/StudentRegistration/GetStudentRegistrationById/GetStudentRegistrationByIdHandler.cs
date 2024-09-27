using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.StudentRegistration.GetStudentRegistrationById;

public class GetStudentRegistrationByIdHandler(IStudentRegistrationRepository studentRegistrationRepository, IMapper mapper) : IRequestHandler<GetStudentRegistrationByIdCommand, StudentRegistrationResponseDto>
{
    public async Task<StudentRegistrationResponseDto> Handle(GetStudentRegistrationByIdCommand request, CancellationToken cancellationToken)
    {
        var studentRegistration =
            await studentRegistrationRepository.GetFirstAsync(x => x.Id == request.studentRegistrationId,
                cancellationToken);
        NotFoundException.ThrowIfNull(studentRegistration);
        return mapper.Map<StudentRegistrationResponseDto>(studentRegistration);
    }
}