using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Feature.Users.GetAllUsers;

public sealed record GetAllUsersQuery() : IRequest<Result<List<GetAllUsersQueryResponse>>>;

