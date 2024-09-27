using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.Trainer.GetAllTrainers;

public record GetAllTrainersCommand : IRequest<IEnumerable<TrainerResponseDto>>;