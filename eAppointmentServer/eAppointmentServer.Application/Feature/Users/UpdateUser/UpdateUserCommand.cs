﻿using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Feature.Users.UpdateUser;

public sealed record UpdateUserCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string UserName,
    List<Guid> RoleIds) : IRequest<Result<string>>;
