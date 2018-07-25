using AutoMapper;
using Employees.Models;
using Employees.ModelsDto;

namespace Employees.App
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, Employee>();
            CreateMap<Employee, PersonalInfoDto>();
            CreateMap<Employee, ManagerDto>()
                .ForMember(dto => dto.CountOfEmployees,
                    opt => opt.MapFrom(src => src.Manager.Employees.Count));
            CreateMap<ManagerDto, Employee>();
            CreateMap<Employee, EmployeesOlderThanDto>()
                .ForMember(dto => dto.ManagerLastName,
                       opt => opt.AllowNull());
        }
    }
}
