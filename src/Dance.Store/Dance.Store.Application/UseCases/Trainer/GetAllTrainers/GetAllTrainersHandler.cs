using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dance.Store.Application.UseCases.Trainer.GetAllTrainers;

public class GetAllTrainersHandler(ITrainerRepository trainerRepository, IMapper mapper) : IRequestHandler<GetAllTrainersCommand, IEnumerable<TrainerResponseDto>>
{
    public async Task<IEnumerable<TrainerResponseDto>> Handle(GetAllTrainersCommand request, CancellationToken cancellationToken)
    {
        var trainers = trainerRepository.GetRange(x => true, cancellationToken);
        return await mapper.ProjectTo<TrainerResponseDto>(trainers).ToListAsync(cancellationToken);
    }
}