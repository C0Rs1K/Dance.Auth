using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.DanceClass.DeleteDanceClass;

public class DeleteDanceClassHandler(IDanceClassRepository danceClassRepository) : IRequestHandler<DeleteDanceClassCommand>
{
    public async Task Handle(DeleteDanceClassCommand request, CancellationToken cancellationToken)
    {
        var danceClass = await danceClassRepository.GetFirstAsync(x => x.Id == request.danceClassId, cancellationToken);
        NotFoundException.ThrowIfNull(danceClass);
        danceClassRepository.Delete(danceClass);
        await danceClassRepository.SaveChangesAsync(cancellationToken);
    }
}