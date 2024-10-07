using MediatR;

namespace Dance.Store.Application.UseCases.Student.DeleteStudent;

public record DeleteStudentCommand(Guid StudentId) : IRequest;