using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Feature.Patients.UpdatePatient;

public sealed record UpdatePatientCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string IdentityNumber,
    string City,
    string Town,
    string FullAddress) : IRequest<Result<string>>;
