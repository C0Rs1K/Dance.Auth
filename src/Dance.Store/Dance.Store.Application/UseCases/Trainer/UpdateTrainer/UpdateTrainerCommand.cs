using Dance.Store.Application.Dtos.RequestDto;
using MediatR;

namespace Dance.Store.Application.UseCases.Trainer.UpdateTrainer;

public record UpdateTrainerCommand(Guid trainerId, TrainerRequestDto trainerRequestDto) : IRequest;