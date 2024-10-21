using MediatR;

namespace Dance.Subscription.Application.Commands.Student;

public record ProcessStudentRegistrationCommand(Domain.Entities.Student Student) : IRequest;