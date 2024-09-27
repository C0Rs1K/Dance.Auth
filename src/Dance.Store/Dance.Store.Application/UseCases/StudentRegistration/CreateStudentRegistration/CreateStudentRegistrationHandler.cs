using AutoMapper;
using Dance.Store.Domain.Entities;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.StudentRegistration.CreateStudentRegistration;

public class CreateStudentRegistrationHandler(IStudentRegistrationRepository studentRegistrationRepository, IMapper mapper) : IRequestHandler<CreateStudentRegistrationCommand, Guid>
{
    public async Task<Guid> Handle(CreateStudentRegistrationCommand request, CancellationToken cancellationToken)
    {
        var studentRegistrationRequestDto = request.studentRegistrationRequestDto;
        var studentRegistration = mapper.Map<StudentRegistrationEntity>(studentRegistrationRequestDto);
        studentRegistrationRepository.Create(studentRegistration);
        await studentRegistrationRepository.SaveChangesAsync(cancellationToken);
        return studentRegistration.Id;
    }
}