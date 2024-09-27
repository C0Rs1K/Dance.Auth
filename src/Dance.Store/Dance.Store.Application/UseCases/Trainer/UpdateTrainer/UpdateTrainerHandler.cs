using AutoMapper;
using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.Trainer.UpdateTrainer;

public class UpdateTrainerHandler(ITrainerRepository trainerRepository, IMapper mapper) : IRequestHandler<UpdateTrainerCommand>
{
    public async Task Handle(UpdateTrainerCommand request, CancellationToken cancellationToken)
    {
        var trainer = await trainerRepository.GetFirstAsync(x => x.Id == request.trainerId, cancellationToken);
        NotFoundException.ThrowIfNull(trainer);
        var trainerDto = request.trainerRequestDto;
        mapper.Map(trainerDto, trainer);
        trainerRepository.Update(trainer);
        await trainerRepository.SaveChangesAsync(cancellationToken);
    }
}