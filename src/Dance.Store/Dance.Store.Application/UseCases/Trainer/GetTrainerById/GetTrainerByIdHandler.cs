using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.Trainer.GetTrainerById;

public class GetTrainerByIdHandler(ITrainerRepository trainerRepository, IMapper mapper) : IRequestHandler<GetTrainerByIdCommand, TrainerResponseDto>
{
    public async Task<TrainerResponseDto> Handle(GetTrainerByIdCommand request, CancellationToken cancellationToken)
    {
        var trainer = await trainerRepository.GetFirstAsync(x => x.Id == request.trainerId, cancellationToken);
        NotFoundException.ThrowIfNull(trainer);
        return mapper.Map<TrainerResponseDto>(trainer);
    }
}