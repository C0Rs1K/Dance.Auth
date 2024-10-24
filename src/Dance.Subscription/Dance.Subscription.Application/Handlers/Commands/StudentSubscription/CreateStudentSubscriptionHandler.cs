using AutoMapper;
using Dance.Subscription.Application.Commands.StudentSubscription;
using Dance.Subscription.Application.Dtos.ResponseDto;
using Dance.Subscription.Domain.Interfaces;
using MediatR;

namespace Dance.Subscription.Application.Handlers.Commands.StudentSubscription;

public class CreateStudentSubscriptionHandler(IStudentSubscriptionRepository studentSubscriptionRepository, IMapper mapper) : 
    IRequestHandler<CreateStudentSubscriptionCommand, StudentSubscriptionResponseDto>
{
    public async Task<StudentSubscriptionResponseDto> Handle(CreateStudentSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var studentSubscription = mapper.Map<Domain.Entities.StudentSubscription>(request.StudentSubscriptionRequestDto);
        await studentSubscriptionRepository.CreateAsync(studentSubscription, cancellationToken);

        return mapper.Map<StudentSubscriptionResponseDto>(studentSubscription);
    }
}