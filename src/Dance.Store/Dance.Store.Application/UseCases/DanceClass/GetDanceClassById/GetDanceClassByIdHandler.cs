using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.DanceClass.GetDanceClassById;

public class GetDanceClassByIdHandler(IDanceClassRepository danceClassRepository, IMapper mapper) : IRequestHandler<GetDanceClassByIdCommand, DanceClassResponseDto>
{
    public async Task<DanceClassResponseDto> Handle(GetDanceClassByIdCommand request, CancellationToken cancellationToken)
    {
        var danceClass = await danceClassRepository.GetFirstAsync(x => x.Id == request.DanceClassId, cancellationToken);
        NotFoundException.ThrowIfNull(danceClass);

        return mapper.Map<DanceClassResponseDto>(danceClass);
    }
}