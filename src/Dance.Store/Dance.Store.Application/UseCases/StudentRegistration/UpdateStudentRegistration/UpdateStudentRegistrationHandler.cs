using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.StudentRegistration.UpdateStudentRegistration;

public class UpdateStudentRegistrationHandler(IStudentRegistrationRepository studentRegistrationRepository, IMapper mapper) : IRequestHandler<UpdateStudentRegistrationCommand, StudentRegistrationResponseDto>
{
    public async Task<StudentRegistrationResponseDto> Handle(UpdateStudentRegistrationCommand request, CancellationToken cancellationToken)
    {
        var studentRegistration =
            await studentRegistrationRepository.GetFirstAsync(x => x.Id == request.StudentRegistrationId,
                cancellationToken);
        NotFoundException.ThrowIfNull(studentRegistration);
        var studentRegistrationDto = request.StudentRegistrationRequestDto;
        mapper.Map(studentRegistrationDto, studentRegistration);
        studentRegistrationRepository.Update(studentRegistration);
        await studentRegistrationRepository.SaveChangesAsync(cancellationToken);

        return mapper.Map<StudentRegistrationResponseDto>(studentRegistration);
    }
}