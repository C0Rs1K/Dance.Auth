using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.DanceClass.CreateDanceClass;

public class CreateDanceClassHandler(IDanceClassRepository danceClassRepository, IMapper mapper) : IRequestHandler<CreateDanceClassCommand, DanceClassResponseDto>
{
    public async Task<DanceClassResponseDto> Handle(CreateDanceClassCommand request, CancellationToken cancellationToken)
    {
        var danceClassDto = request.DanceClassRequestDto;
        var danceClass = mapper.Map<Domain.Entities.DanceClass>(danceClassDto);
        danceClassRepository.Create(danceClass);
        await danceClassRepository.SaveChangesAsync(cancellationToken);

        return mapper.Map<DanceClassResponseDto>(danceClass);
    }
}