﻿using MediatR;

namespace Dance.Subscription.Application.Commands.StudentSubscription;

public record DeleteExpiredSubscriptionCommand : IRequest;