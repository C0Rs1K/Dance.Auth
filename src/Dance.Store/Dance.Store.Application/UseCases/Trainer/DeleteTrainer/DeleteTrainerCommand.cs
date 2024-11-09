using MediatR;

namespace Dance.Store.Application.UseCases.Trainer.DeleteTrainer;

public record DeleteTrainerCommand(Guid TrainerId) : IRequest;