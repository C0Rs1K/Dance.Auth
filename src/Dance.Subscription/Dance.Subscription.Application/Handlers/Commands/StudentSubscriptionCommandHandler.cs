using AutoMapper;
using Dance.Subscription.Application.Commands.StudentSubscription;
using Dance.Subscription.Application.Dtos.ResponseDto;
using Dance.Subscription.Application.Exceptions;
using Dance.Subscription.Domain.Entities;
using Dance.Subscription.Domain.Interfaces;
using MediatR;
using MongoDB.Bson;

namespace Dance.Subscription.Application.Handlers.Commands;

public class StudentSubscriptionCommandHandler(
    IStudentSubscriptionRepository studentSubscriptionRepository,
    IMapper mapper) :
        IRequestHandler<CreateStudentSubscriptionCommand, StudentSubscriptionResponseDto>,
        IRequestHandler<UpdateStudentSubscriptionCommand, StudentSubscriptionResponseDto>,
        IRequestHandler<DeleteStudentSubscriptionCommand>
{ 
    public async Task<StudentSubscriptionResponseDto> Handle(CreateStudentSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var studentSubscription = mapper.Map<StudentSubscription>(request.StudentSubscriptionRequestDto);
        await studentSubscriptionRepository.CreateAsync(studentSubscription, cancellationToken);    

        return mapper.Map<StudentSubscriptionResponseDto>(studentSubscription);
    }

    public async Task<StudentSubscriptionResponseDto> Handle(UpdateStudentSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var studentSubscription =
            await studentSubscriptionRepository.GetFirstAsync(x => x.Id == new ObjectId(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(studentSubscription);
        mapper.Map(request.StudentSubscriptionRequestDto, studentSubscription);
        await studentSubscriptionRepository.UpdateAsync(request.Id, studentSubscription, cancellationToken);

        return mapper.Map<StudentSubscriptionResponseDto>(studentSubscription);
    }

    public async Task Handle(DeleteStudentSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var studentSubscription = await studentSubscriptionRepository.GetFirstAsync(x => x.Id == new ObjectId(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(studentSubscription);
        await studentSubscriptionRepository.DeleteAsync(request.Id, cancellationToken);
    }
}
