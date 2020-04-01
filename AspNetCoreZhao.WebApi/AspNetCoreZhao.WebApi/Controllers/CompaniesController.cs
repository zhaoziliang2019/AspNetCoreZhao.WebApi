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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;

        public CompaniesController(ICompanyRepository _companyRepository,IMapper mapper)
        {
            this.companyRepository = _companyRepository??throw new ArgumentNullException(nameof(_companyRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        /// <summary>
        /// 获取所有的公司
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{GetCompanies}")]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanies()
        {
            var companies = await companyRepository.GetCompaniesAsync();
            var companyDto= mapper.Map<IEnumerable<CompanyDto>>(companies);
            return Ok(companyDto);
        }
        [HttpGet]
        [Route("{GetCompany}/{companyId}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(Guid companyId)
        {
            if (companyId==Guid.Empty)
            {
                return NotFound();
            }
            var company = await companyRepository.GetCompanyAsync(companyId);
            var companyDto = mapper.Map<CompanyDto>(company);
            return Ok(companyDto);
        }
    }
}