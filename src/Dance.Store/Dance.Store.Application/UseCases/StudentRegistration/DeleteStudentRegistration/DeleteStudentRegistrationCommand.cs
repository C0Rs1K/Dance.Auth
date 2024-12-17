﻿using MediatR;

namespace Dance.Store.Application.UseCases.StudentRegistration.DeleteStudentRegistration;

public record DeleteStudentRegistrationCommand(Guid StudentRegistrationId) : IRequest;