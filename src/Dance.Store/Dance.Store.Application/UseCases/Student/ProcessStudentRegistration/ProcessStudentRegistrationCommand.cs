using MediatR;

namespace Dance.Store.Application.UseCases.Student.ProcessStudentRegistration;

public record ProcessStudentRegistrationCommand(Domain.Entities.Student Student) : IRequest;