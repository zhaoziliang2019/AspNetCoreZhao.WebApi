using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreZhao.WebApi.Entities;
using AspNetCoreZhao.WebApi.Models;
using AspNetCoreZhao.WebApi.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreZhao.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICompanyRepository companyRepository;

        public EmployeeController(IMapper _mapper, ICompanyRepository _companyRepository)
        {
            mapper = _mapper??throw new ArgumentNullException(nameof(_mapper));
            companyRepository = _companyRepository??throw new ArgumentNullException(nameof(_companyRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeeForCompany(Guid companyId)
        {
            if (!await companyRepository.CompanyExistsAsync(companyId))
            {
                return NotFound();
            }
            var gender = Enum.Parse<Gender>("男");
            var employees = await companyRepository.GetEmployeesAsync(companyId);
            var employeeDtos = mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }
    }
}