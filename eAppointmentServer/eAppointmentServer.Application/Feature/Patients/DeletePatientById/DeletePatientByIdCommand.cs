using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Feature.Patients.DeletePatientById;

public sealed record DeletePatientByIdCommand(Guid Id)  : IRequest<Result<string>>;
