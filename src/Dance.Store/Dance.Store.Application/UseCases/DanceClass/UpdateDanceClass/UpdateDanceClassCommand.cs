using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.DanceClass.UpdateDanceClass;

public record UpdateDanceClassCommand(Guid DanceClassId, DanceClassRequestDto DanceClassRequestDto) : IRequest<DanceClassResponseDto>, IRequest;