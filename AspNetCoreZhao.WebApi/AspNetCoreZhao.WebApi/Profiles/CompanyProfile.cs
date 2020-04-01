using AspNetCoreZhao.WebApi.Entities;
using AspNetCoreZhao.WebApi.Models;
using AutoMapper;

namespace AspNetCoreZhao.WebApi.Profiles
{
    public class CompanyProfile:Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>().ForMember(dest=>dest.CompanyName,opt=>opt.MapFrom(src=>src.Name));
        }
    }
}
