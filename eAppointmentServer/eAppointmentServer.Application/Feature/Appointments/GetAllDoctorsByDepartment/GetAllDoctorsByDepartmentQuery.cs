using eAppointmentServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Feature.Appointments.GetAllDoctorsByDepartment;

public sealed record GetAllDoctorsByDepartmentQuery(int DepartmentValue) : IRequest<Result<List<Doctor>>>;
