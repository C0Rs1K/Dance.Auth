using AutoMapper;
using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.DanceClass.UpdateDanceClass;

public class UpdateDanceClassHandler(IDanceClassRepository danceClassRepository, IMapper mapper) : IRequestHandler<UpdateDanceClassCommand>
{
    public async Task Handle(UpdateDanceClassCommand request, CancellationToken cancellationToken)
    {
        var danceClass = await danceClassRepository.GetFirstAsync(x => x.Id == request.danceClassId, cancellationToken);
        NotFoundException.ThrowIfNull(danceClass);
        var danceClassDto = request.danceClassRequestDto;
        mapper.Map(danceClassDto, danceClass);
        danceClassRepository.Update(danceClass);
        await danceClassRepository.SaveChangesAsync(cancellationToken);
    }
}