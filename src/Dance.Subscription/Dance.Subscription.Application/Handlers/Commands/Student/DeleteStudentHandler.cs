using AutoMapper;
using Dance.Subscription.Application.Commands.Student;
using Dance.Subscription.Application.Exceptions;
using Dance.Subscription.Domain.Interfaces;
using MediatR;
using MongoDB.Bson;

namespace Dance.Subscription.Application.Handlers.Commands.Student;

public class DeleteStudentHandler(IStudentRepository studentRepository, IMapper mapper) : IRequestHandler<DeleteStudentCommand>
{
    public async Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await studentRepository.GetFirstAsync(x => x.Id == new ObjectId(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(student);
        await studentRepository.DeleteAsync(request.Id, cancellationToken);
    }
}