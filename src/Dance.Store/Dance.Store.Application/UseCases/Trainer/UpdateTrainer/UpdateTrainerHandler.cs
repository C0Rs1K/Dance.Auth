using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.Trainer.UpdateTrainer;

public class UpdateTrainerHandler(ITrainerRepository trainerRepository, IMapper mapper) : IRequestHandler<UpdateTrainerCommand, TrainerResponseDto>
{
    public async Task<TrainerResponseDto> Handle(UpdateTrainerCommand request, CancellationToken cancellationToken)
    {
        var trainer = await trainerRepository.GetFirstAsync(x => x.Id == request.TrainerId, cancellationToken);
        NotFoundException.ThrowIfNull(trainer);
        var trainerDto = request.TrainerRequestDto;
        mapper.Map(trainerDto, trainer);
        trainerRepository.Update(trainer);
        await trainerRepository.SaveChangesAsync(cancellationToken);

        return mapper.Map<TrainerResponseDto>(trainer);
    }
}