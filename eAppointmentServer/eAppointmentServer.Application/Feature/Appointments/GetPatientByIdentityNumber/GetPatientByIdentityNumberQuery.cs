using eAppointmentServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Feature.Appointments.GetPatientByIdentityNumber
{
    public sealed record GetPatientByIdentityNumberQuery(string IdentityNumber) : IRequest<Result<Patient>>;
}
