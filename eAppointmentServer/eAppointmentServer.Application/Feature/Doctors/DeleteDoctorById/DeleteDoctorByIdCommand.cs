using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Feature.Doctors.DeleteDoctorById;

public sealed record DeleteDoctorByIdCommand(Guid id) : IRequest<Result<string>>;
