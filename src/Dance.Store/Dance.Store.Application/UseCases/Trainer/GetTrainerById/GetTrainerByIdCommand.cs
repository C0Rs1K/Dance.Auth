using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.Trainer.GetTrainerById;

public record GetTrainerByIdCommand(Guid TrainerId) : IRequest<TrainerResponseDto>;