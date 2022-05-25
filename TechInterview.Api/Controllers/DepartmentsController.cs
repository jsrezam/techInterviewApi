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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentsController(IMapper mapper, IDepartmentService departmentService)
        {
            _mapper = mapper;
            _departmentService = departmentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentDto departmentDto)
        {
            var department = _mapper.Map<CreateDepartmentDto, Department>(departmentDto);
            await _departmentService.AddDepartmentAsync(department);
            var result = _mapper.Map<Department, CreateDepartmentDto>(department);
            var response = new ApiResponse<CreateDepartmentDto>(result);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var department = await _departmentService.GetDepartmentEagerAsync(id);
            var result = _mapper.Map<Department, DepartmentDto>(department);
            var response = new ApiResponse<DepartmentDto>(result);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _departmentService.GetAllDepartmentsEagerAsync();
            var result = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDto>>(departments);
            var response = new ApiResponse<IEnumerable<DepartmentDto>>(result);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, UpdateDepartmentDto departmentDto)
        {
            var department = await _departmentService.GetDepartmentEagerAsync(id);
            _mapper.Map(departmentDto, department);
            var result = await _departmentService.UpdateDepartmentAsync(department);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpGet("byEnterprice/{id}")]
        public async Task<IActionResult> GetDepartmentsByEnterpriseId(int id)
        {
            var departments = await _departmentService.GetDepartmentsByEnterprise(id);
            var result = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDto>>(departments);
            var response = new ApiResponse<IEnumerable<DepartmentDto>>(result);
            return Ok(response);
        }
    }
}