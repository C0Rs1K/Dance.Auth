using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dance.Store.Application.UseCases.DanceClass.GetAllDanceClasses;

public class GetAllDanceClassesHandler(IDanceClassRepository danceClassRepository, IMapper mapper) : IRequestHandler<GetAllDanceClassesCommand, IEnumerable<DanceClassResponseDto>>
{
    public async Task<IEnumerable<DanceClassResponseDto>> Handle(GetAllDanceClassesCommand request, CancellationToken cancellationToken)
    {
        var danceClasses = danceClassRepository.GetRange(x => true, cancellationToken);
        return await mapper.ProjectTo<DanceClassResponseDto>(danceClasses).ToListAsync(cancellationToken);
    }
}