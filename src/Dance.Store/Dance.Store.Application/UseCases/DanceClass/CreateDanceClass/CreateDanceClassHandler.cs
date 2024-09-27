using AutoMapper;
using Dance.Store.Domain.Entities;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.DanceClass.CreateDanceClass;

public class CreateDanceClassHandler(IDanceClassRepository danceClassRepository, IMapper mapper) : IRequestHandler<CreateDanceClassCommand, Guid>
{
    public async Task<Guid> Handle(CreateDanceClassCommand request, CancellationToken cancellationToken)
    {
        var danceClassDto = request.danceClassRequestDto;
        var danceClass = mapper.Map<DanceClassEntity>(danceClassDto);
        danceClassRepository.Create(danceClass);
        await danceClassRepository.SaveChangesAsync(cancellationToken);
        return danceClass.Id;
    }
}