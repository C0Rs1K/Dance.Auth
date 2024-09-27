using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.DanceClass.GetAllDanceClasses;

public record GetAllDanceClassesCommand : IRequest<IEnumerable<DanceClassResponseDto>>;