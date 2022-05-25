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
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IMapper mapper, IEmployeeService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<CreateEmployeeDto, Employee>(employeeDto);
            await _employeeService.AddEmployeeAsync(employee);
            var result = _mapper.Map<Employee, CreateEmployeeDto>(employee);
            var response = new ApiResponse<CreateEmployeeDto>(result);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDto employeeDto)
        {
            var employee = await _employeeService.GetEmployeeEagerAsync(id);
            _mapper.Map(employeeDto, employee);
            var result = await _employeeService.UpdateEmployeeAsync(employee);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesEagerAsync();
            var result = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            var response = new ApiResponse<IEnumerable<EmployeeDto>>(result);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeEagerAsync(id);
            var result = _mapper.Map<Employee, EmployeeDto>(employee);
            var response = new ApiResponse<EmployeeDto>(result);
            return Ok(response);
        }
    }
}