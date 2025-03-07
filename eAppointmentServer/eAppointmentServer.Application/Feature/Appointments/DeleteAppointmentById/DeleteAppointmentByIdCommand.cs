using AutoMapper;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Feature.Appointments.DeleteAppointmentById;

public sealed record DeleteAppointmentByIdCommand(
    Guid Id
    ) : IRequest<Result<string>>;

