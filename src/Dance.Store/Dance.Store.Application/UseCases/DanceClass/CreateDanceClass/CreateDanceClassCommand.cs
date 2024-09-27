using Dance.Store.Application.Dtos.RequestDto;
using MediatR;

namespace Dance.Store.Application.UseCases.DanceClass.CreateDanceClass;

public record CreateDanceClassCommand(DanceClassRequestDto danceClassRequestDto) : IRequest<Guid>;