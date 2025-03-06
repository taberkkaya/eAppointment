using eAppointmentServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Feature.Doctors.GetAllDoctor;

public sealed record GetAllDoctorQuery() : IRequest<Result<List<Doctor>>>;
