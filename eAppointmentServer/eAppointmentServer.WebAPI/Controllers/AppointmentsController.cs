using eAppointmentServer.Application.Feature.Appointments.CreateAppointment;
using eAppointmentServer.Application.Feature.Appointments.DeleteAppointmentById;
using eAppointmentServer.Application.Feature.Appointments.GetAllAppointments;
using eAppointmentServer.Application.Feature.Appointments.GetAllDoctorsByDepartment;
using eAppointmentServer.Application.Feature.Appointments.GetPatientByIdentityNumber;
using eAppointmentServer.Application.Feature.Appointments.UpdateAppointment;
using eAppointmentServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eAppointmentServer.WebAPI.Controllers
{
    public class AppointmentsController : ApiController
    {
        public AppointmentsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAllDoctorByDepartment(GetAllDoctorsByDepartmentQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request,cancellationToken);
            return StatusCode(response.StatusCode,response);
        }        
        [HttpPost]
        public async Task<IActionResult> GetAllByDoctorId(GetAllAppointmentsByDoctorIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request,cancellationToken);
            return StatusCode(response.StatusCode,response);
        }

        [HttpPost]
        public async Task<IActionResult> GetPatientByIdentityNumber(GetPatientByIdentityNumberQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteAppointmentByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
