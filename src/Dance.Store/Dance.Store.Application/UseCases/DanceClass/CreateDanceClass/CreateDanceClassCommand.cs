using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.DanceClass.CreateDanceClass;

public record CreateDanceClassCommand(DanceClassRequestDto DanceClassRequestDto) : IRequest<DanceClassResponseDto>;