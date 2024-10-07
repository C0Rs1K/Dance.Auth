using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.StudentRegistration.CreateStudentRegistration;

public class CreateStudentRegistrationHandler(IStudentRegistrationRepository studentRegistrationRepository, IMapper mapper) : IRequestHandler<CreateStudentRegistrationCommand, StudentRegistrationResponseDto>
{
    public async Task<StudentRegistrationResponseDto> Handle(CreateStudentRegistrationCommand request, CancellationToken cancellationToken)
    {
        var studentRegistrationRequestDto = request.StudentRegistrationRequestDto;
        var studentRegistration = mapper.Map<Domain.Entities.StudentRegistration>(studentRegistrationRequestDto);
        studentRegistrationRepository.Create(studentRegistration);
        await studentRegistrationRepository.SaveChangesAsync(cancellationToken);

        return mapper.Map<StudentRegistrationResponseDto>(studentRegistration);
    }
}