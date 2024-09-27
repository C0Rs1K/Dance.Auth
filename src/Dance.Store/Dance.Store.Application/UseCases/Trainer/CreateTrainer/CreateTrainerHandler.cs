using AutoMapper;
using Dance.Store.Domain.Entities;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.Trainer.CreateTrainer;

public class CreateTrainerHandler(ITrainerRepository trainerRepository, IMapper mapper) : IRequestHandler<CreateTrainerCommand, Guid>
{
    public async Task<Guid> Handle(CreateTrainerCommand request, CancellationToken cancellationToken)
    {
        var trainerRequestDto = request.trainerRequestDto;
        var trainer = mapper.Map<TrainerEntity>(trainerRequestDto);
        trainerRepository.Create(trainer);
        await trainerRepository.SaveChangesAsync(cancellationToken);
        return trainer.Id;
    }
}