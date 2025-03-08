using AutoMapper;
using eAppointmentServer.Application.Feature.Doctors.CreateDoctor;
using eAppointmentServer.Application.Feature.Doctors.UpdateDoctor;
using eAppointmentServer.Application.Feature.Patients.CreatePatient;
using eAppointmentServer.Application.Feature.Patients.UpdatePatient;
using eAppointmentServer.Application.Feature.Users.CreateUser;
using eAppointmentServer.Application.Feature.Users.UpdateUser;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Enums;

namespace eAppointmentServer.Application.Mapping;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateDoctorCommand, Doctor>().ForMember(member => member.Department, options =>
        {
            options.MapFrom(map => DepartmentEnum.FromValue(map.DepartmentValue));
        }).ReverseMap();        
        
        CreateMap<UpdateDoctorCommand, Doctor>().ForMember(member => member.Department, options =>
        {
            options.MapFrom(map => DepartmentEnum.FromValue(map.DepartmentValue));
        }).ReverseMap();

        CreateMap<CreatePatientCommand, Patient>();
        CreateMap<UpdatePatientCommand, Patient>();

        CreateMap<CreateUserCommand, AppUser>();
        CreateMap<UpdateUserCommand, AppUser>();
        

    }
}
