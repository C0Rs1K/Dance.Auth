﻿using MediatR;

namespace Dance.Store.Application.UseCases.DanceClass.DeleteDanceClass;

public record DeleteDanceClassCommand(Guid DanceClassId) : IRequest;