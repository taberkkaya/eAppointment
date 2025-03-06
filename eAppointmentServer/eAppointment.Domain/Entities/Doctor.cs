using eAppointmentServer.Domain.Enums;

namespace eAppointmentServer.Domain.Entities;

public sealed class Doctor : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", FirstName, LastName);
    public DepartmentEnum Department { get; set; } = DepartmentEnum.Acil;
}
