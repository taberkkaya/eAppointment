using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Feature.Roles.RoleSync;

public sealed record RoleSyncCommand(): IRequest<Result<string>>;
