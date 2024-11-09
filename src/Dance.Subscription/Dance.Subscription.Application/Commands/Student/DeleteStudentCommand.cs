using MediatR;

namespace Dance.Subscription.Application.Commands.Student;

public record DeleteStudentCommand(string Id) : IRequest;