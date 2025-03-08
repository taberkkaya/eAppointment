using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Feature.Appointments.UpdateAppointment;

public sealed record UpdateAppointmentCommand(Guid Id,string StartDate, string EndDate) : IRequest<Result<string>>;

