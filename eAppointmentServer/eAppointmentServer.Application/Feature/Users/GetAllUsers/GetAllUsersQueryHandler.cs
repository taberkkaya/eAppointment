using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppointmentServer.Application.Feature.Users.GetAllUsers;

internal sealed class GetAllUsersQueryHandler(
    UserManager<AppUser> userManager,
    RoleManager<AppRole> roleManager,
    IUserRoleRepository userRoleRepository
    ) : IRequestHandler<GetAllUsersQuery, Result<List<GetAllUsersQueryResponse>>>
{
    public async Task<Result<List<GetAllUsersQueryResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        List<AppUser> users = await userManager.Users.OrderBy(p => p.FirstName).ToListAsync(cancellationToken);

        List<GetAllUsersQueryResponse> response =
            users.Select(s => new GetAllUsersQueryResponse
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                UserName = s.UserName,
            }).ToList();

        foreach(var user in response)
        {
            List<AppUserRole> userRoles = await userRoleRepository
                .Where(p => p.UserId == user.Id)
                .ToListAsync(cancellationToken);

            foreach(var userRole in userRoles)
            {
                List<AppRole> roles = await roleManager.Roles
                    .Where(p => p.Id == userRole.RoleId)
                    .ToListAsync(cancellationToken);

                List<string?> stringRoles = roles.Select(p => p.Name).ToList();
                user.RoleIds = stringRoles;
            }
        }

        return response;
    }
}

