using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.Trainer.CreateTrainer;

public record CreateTrainerCommand(TrainerRequestDto TrainerRequestDto) : IRequest<TrainerResponseDto>;