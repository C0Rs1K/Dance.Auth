using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.DanceClass.UpdateDanceClass;

public class UpdateDanceClassHandler(IDanceClassRepository danceClassRepository, IMapper mapper) : IRequestHandler<UpdateDanceClassCommand, DanceClassResponseDto>
{
    public async Task<DanceClassResponseDto> Handle(UpdateDanceClassCommand request, CancellationToken cancellationToken)
    {
        var danceClass = await danceClassRepository.GetFirstAsync(x => x.Id == request.DanceClassId, cancellationToken);
        NotFoundException.ThrowIfNull(danceClass);
        var danceClassDto = request.DanceClassRequestDto;
        mapper.Map(danceClassDto, danceClass);
        danceClassRepository.Update(danceClass);
        await danceClassRepository.SaveChangesAsync(cancellationToken);

        return mapper.Map<DanceClassResponseDto>(danceClass);
    }
}