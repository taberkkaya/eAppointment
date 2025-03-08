using eAppointmentServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppointmentServer.Application.Feature.Users.GetAllRolesForUsers;

internal sealed class GetAllRolesForUsersQueryHandler(RoleManager<AppRole> roleManager) : IRequestHandler<GetAllRolesForUsersQuery, Result<List<AppRole>>>
{
    public async Task<Result<List<AppRole>>> Handle(GetAllRolesForUsersQuery request, CancellationToken cancellationToken)
    {
        List<AppRole> roles = await roleManager.Roles.ToListAsync(cancellationToken);
        return roles;
    }
}
