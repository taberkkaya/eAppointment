using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Feature.Appointments.CreateAppointment
{
    public sealed record CreateAppointmentCommand(
        string StartDate, 
        string EndDate, 
        Guid DoctorId,
        Guid? PatientId,
        string FirstName,
        string LastName,
        string IdentityNumber,
        string City,
        string Town,
        string FullAddress): IRequest<Result<string>>;
}
