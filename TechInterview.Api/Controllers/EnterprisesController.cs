using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechInterview.Api.Responses;
using TechInterview.Core.DTOs;
using TechInterview.Core.Entities;
using TechInterview.Core.Interfaces;

namespace TechInterview.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnterprisesController : ControllerBase
    {
        private readonly IEnterpriseService _enterpriseService;
        private readonly IMapper _mapper;

        public EnterprisesController(IEnterpriseService enterpriseService, IMapper mapper)
        {
            _enterpriseService = enterpriseService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEnterprise(CreateEnterpriseDto enterpriseDto)
        {
            var enterprise = _mapper.Map<Enterprise>(enterpriseDto);
            await _enterpriseService.AddEnterpriseAsync(enterprise);
            enterpriseDto = _mapper.Map<CreateEnterpriseDto>(enterprise);
            var response = new ApiResponse<CreateEnterpriseDto>(enterpriseDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnterprise(int id)
        {
            var enterprise = await _enterpriseService.GetEnterpriseAsync(id);
            var enterprisesDto = _mapper.Map<EnterprisesDto>(enterprise);
            var response = new ApiResponse<EnterprisesDto>(enterprisesDto);
            return Ok(response);
        }

        [HttpGet("byEmployee/{id}")]
        public async Task<IActionResult> GetEnterpriseByEmployee(int id)
        {
            var enterprise = await _enterpriseService.GetEnterpriseByEmployeeAsync(id);
            var enterprisesDto = _mapper.Map<EnterprisesDto>(enterprise);
            var response = new ApiResponse<EnterprisesDto>(enterprisesDto);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetEnterprises()
        {
            var enterprises = await _enterpriseService.GetAllEnterprisesAsync();
            var enterprisesDto = _mapper.Map<IEnumerable<EnterprisesDto>>(enterprises);
            var response = new ApiResponse<IEnumerable<EnterprisesDto>>(enterprisesDto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnerprise(int id, UpdateEnterpriseDto enterpriseDto)
        {
            var enterprise = await _enterpriseService.GetEnterpriseAsync(id);
            _mapper.Map(enterpriseDto, enterprise);
            var result = await _enterpriseService.UpdateEnterpriseAsync(enterprise);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}