using Dance.Store.Application.Dtos.RequestDto;
using MediatR;

namespace Dance.Store.Application.UseCases.Trainer.CreateTrainer;

public record CreateTrainerCommand(TrainerRequestDto trainerRequestDto) : IRequest<Guid>;