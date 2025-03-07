using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Feature.Appointments.GetAllAppointments
{
    public sealed record GetAllAppointmentsByDoctorIdQuery(Guid DoctorId) : IRequest<Result<List<GetAllAppointmentsByDoctorIdQueryResponse>>>;
}
