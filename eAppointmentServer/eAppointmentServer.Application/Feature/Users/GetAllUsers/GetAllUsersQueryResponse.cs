namespace eAppointmentServer.Application.Feature.Users.GetAllUsers;

public sealed record GetAllUsersQueryResponse()
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName {get; set;} = string.Empty;
    public string? Email {get; set;}
    public string? UserName {get; set;}
    public List<string?> RoleIds { get; set; } = new();
}

