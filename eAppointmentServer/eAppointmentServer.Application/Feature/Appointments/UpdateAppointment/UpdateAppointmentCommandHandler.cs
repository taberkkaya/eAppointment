using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TS.Result;

namespace eAppointmentServer.Application.Feature.Appointments.UpdateAppointment;

internal sealed class UpdateAppointmentCommandHandler(
    IAppointmentRepository appointmentRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateAppointmentCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {

        DateTime startDate = Convert.ToDateTime(request.StartDate);
        DateTime endDate = Convert.ToDateTime(request.EndDate);

        Appointment? appointment = await appointmentRepository
            .GetByExpressionWithTrackingAsync(x => x.Id == request.Id, cancellationToken);

        if (appointment is null)
            return "Appointment not found!";

        bool isAppointmentDateNotAvailable = await appointmentRepository
            .AnyAsync(p => p.DoctorId == appointment.DoctorId &&
            p.Id != appointment.Id &&
             ((p.StartDate < endDate && p.StartDate >= startDate) || 
             (p.EndDate > startDate && p.EndDate <= endDate) || 
             (p.StartDate >= startDate && p.EndDate <= endDate) || 
             (p.StartDate <= startDate && p.EndDate >= endDate)), 
             cancellationToken);

        if (isAppointmentDateNotAvailable)
            return Result<string>.Failure("Appointment date is not available!");

        appointment.StartDate = Convert.ToDateTime(request.StartDate);
        appointment.EndDate = Convert.ToDateTime(request.EndDate);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Appointment update is successful";

    }
}

