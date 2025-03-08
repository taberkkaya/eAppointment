using eAppointmentServer.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TS.Result;

namespace eAppointmentServer.Application.Feature.Users.DeleteUserById;

internal sealed class DeleteUserByIdCommandHandler(
    UserManager<AppUser> userManager,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByIdAsync(request.Id.ToString());
        
        if (user is null)
            return Result<string>.Failure("User not found!");

        IdentityResult result = await userManager.DeleteAsync(user);

        if (!result.Succeeded)
            return Result<string>.Failure(result.Errors.Select(s => s.Description).ToList());

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "User delete is successful!";
    }
}

