using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Domain.Entities;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.Trainer.CreateTrainer;

public class CreateTrainerHandler(ITrainerRepository trainerRepository, IMapper mapper) : IRequestHandler<CreateTrainerCommand, TrainerResponseDto>
{
    public async Task<TrainerResponseDto> Handle(CreateTrainerCommand request, CancellationToken cancellationToken)
    {
        var trainerRequestDto = request.TrainerRequestDto;
        var trainer = mapper.Map<Domain.Entities.Trainer>(trainerRequestDto);
        trainerRepository.Create(trainer);
        await trainerRepository.SaveChangesAsync(cancellationToken);

        return mapper.Map<TrainerResponseDto>(trainer);
    }
}