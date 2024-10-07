using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.Trainer.DeleteTrainer;

public class DeleteTrainerHandler(ITrainerRepository trainerRepository) : IRequestHandler<DeleteTrainerCommand>
{
    public async Task Handle(DeleteTrainerCommand request, CancellationToken cancellationToken)
    {
        var trainer = await trainerRepository.GetFirstAsync(x => x.Id == request.TrainerId, cancellationToken);
        NotFoundException.ThrowIfNull(trainer);
        trainerRepository.Delete(trainer);
        await trainerRepository.SaveChangesAsync(cancellationToken);
    }
}