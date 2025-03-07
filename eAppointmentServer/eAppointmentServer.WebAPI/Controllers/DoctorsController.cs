using eAppointmentServer.Application.Feature.Doctors.CreateDoctor;
using eAppointmentServer.Application.Feature.Doctors.DeleteDoctorById;
using eAppointmentServer.Application.Feature.Doctors.GetAllDoctor;
using eAppointmentServer.Application.Feature.Doctors.UpdateDoctor;
using eAppointmentServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TS.Result;

namespace eAppointmentServer.WebAPI.Controllers
{
    public class DoctorsController : ApiController
    {
        public DoctorsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllDoctorQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            //var response = Result<string>.Failure(new List<string>(){ "Example Error!", "Example Error-2!", "Example Error-3!" });
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }        
        
        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteDoctorByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }        
        
        [HttpPost]
        public async Task<IActionResult> Update(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
