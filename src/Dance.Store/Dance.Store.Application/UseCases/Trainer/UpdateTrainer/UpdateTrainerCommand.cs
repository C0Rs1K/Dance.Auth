using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.Trainer.UpdateTrainer;

public record UpdateTrainerCommand(Guid TrainerId, TrainerRequestDto TrainerRequestDto) : IRequest<TrainerResponseDto>;