using AutoMapper;
using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.StudentRegistration.UpdateStudentRegistration;

public class UpdateStudentRegistrationHandler(IStudentRegistrationRepository studentRegistrationRepository, IMapper mapper) : IRequestHandler<UpdateStudentRegistrationCommand>
{
    public async Task Handle(UpdateStudentRegistrationCommand request, CancellationToken cancellationToken)
    {
        var studentRegistration =
            await studentRegistrationRepository.GetFirstAsync(x => x.Id == request.studentRegistrationId,
                cancellationToken);
        NotFoundException.ThrowIfNull(studentRegistration);
        var studentRegistrationDto = request.studentRegistrationRequestDto;
        mapper.Map(studentRegistrationDto, studentRegistration);
        studentRegistrationRepository.Update(studentRegistration);
        await studentRegistrationRepository.SaveChangesAsync(cancellationToken);
    }
}