using AspNetCoreZhao.WebApi.Entities;
using AspNetCoreZhao.WebApi.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreZhao.WebApi.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName}{src.LastName}")).ForMember(dest => dest.gender, opt => opt.MapFrom(src => src.gender.ToString())).ForMember(dest => dest.Age, opt => opt.MapFrom(src => System.DateTime.Now.Year - src.DateOfBirth.Year));
        }
    }
}
