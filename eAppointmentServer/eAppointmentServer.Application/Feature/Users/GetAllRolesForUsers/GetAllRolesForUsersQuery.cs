using eAppointmentServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Feature.Users.GetAllRolesForUsers;

public sealed record GetAllRolesForUsersQuery() : IRequest<Result<List<AppRole>>>;
