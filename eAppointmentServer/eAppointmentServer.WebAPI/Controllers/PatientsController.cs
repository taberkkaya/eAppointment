using eAppointmentServer.Application.Feature.Patients.CreatePatient;
using eAppointmentServer.Application.Feature.Patients.DeletePatientById;
using eAppointmentServer.Application.Feature.Patients.GetAllPatient;
using eAppointmentServer.Application.Feature.Patients.UpdatePatient;
using eAppointmentServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eAppointmentServer.WebAPI.Controllers
{
    public class PatientsController : ApiController
    {
        public PatientsController(IMediator mediator) : base(mediator)
        {
        }


        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllPatientQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            //var response = Result<string>.Failure(new List<string>(){ "Example Error!", "Example Error-2!", "Example Error-3!" });
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(DeletePatientByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
