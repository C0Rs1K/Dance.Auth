using Dance.Store.Application.Dtos.RequestDto;
using MediatR;

namespace Dance.Store.Application.UseCases.DanceClass.UpdateDanceClass;

public record UpdateDanceClassCommand(Guid danceClassId, DanceClassRequestDto danceClassRequestDto) : IRequest;