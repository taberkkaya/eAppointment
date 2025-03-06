namespace eAppointmentServer.Domain.Entities;

public sealed class Appointment  : BaseEntity
{
    public Guid DoctorId { get; set; }
    public Doctor? Doctor { get; set; }

    public Guid PatientId { get; set; }
    public Patient? Patient { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsCompleted { get; set; }
}
