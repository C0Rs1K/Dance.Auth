using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.DanceClass.GetDanceClassById;

public record GetDanceClassByIdCommand(Guid DanceClassId) : IRequest<DanceClassResponseDto>;