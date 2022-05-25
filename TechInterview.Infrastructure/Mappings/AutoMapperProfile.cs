using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TechInterview.Core.DTOs;
using TechInterview.Core.Entities;

namespace TechInterview.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Domian to Api Dtos
            CreateMap<Enterprise, CreateEnterpriseDto>();
            CreateMap<Enterprise, EnterprisesDto>();
            CreateMap<Department, CreateDepartmentDto>()
                .ForMember(dto => dto.Employees, opt => opt
                    .MapFrom(d => d.Employees
                        .Select(e => e.EmployeeId)));
            CreateMap<Department, DepartmentDto>();
            CreateMap<Employee, CreateEmployeeDto>()
                .ForMember(dto => dto.Departments, opt => opt
                    .MapFrom(e => e.Departments
                        .Select(d => d.DepartmentId)));
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dto => dto.Departments, opt => opt
                  .MapFrom(e => e.Departments
                  .Select(d => d.DepartmentId)));
                //.ForMember(dto=>dto.EnterpriseId,opt=>opt
                //.MapFrom(e=>e.Departments.FirstOrDefault(d=>d.EmployeeId ==e.Id).Department.Enterprise.Id));
                //.AfterMap((e, dto) =>
                //{
                //   dto.EnterpriseId = e.Departments.FirstOrDefault(d => d.EmployeeId == dto.Id).Department?.EnterpriseId ?? 0;
                //});
                

            //Dtos to Api Domain
            CreateMap<CreateEnterpriseDto, Enterprise>()
                .AfterMap((dto, e) =>
                {
                    e.CreatedDate = DateTime.Now;
                    e.Status = true;
                });            

            CreateMap<UpdateEnterpriseDto, Enterprise>()
                .ForMember(e => e.CreatedBy, opt => opt.Ignore())
                .ForMember(e => e.CreatedDate, opt => opt.Ignore())
                .AfterMap((dto, e) =>
                {
                    e.ModifiedDate = DateTime.Now;
                });
            
            CreateMap<CreateDepartmentDto, Department>()
                .ForMember(d => d.Employees, opt => 
                    opt.MapFrom(dto => dto.Employees
                        .Select(id => new DepartmentEmployee { 
                            EmployeeId = id
                            ,CreatedBy = dto.CreatedBy
                            ,CreatedDate = DateTime.Now
                            ,Status = true
                        })))
                .AfterMap((dto, d) =>
                {
                    d.CreatedDate = DateTime.Now;
                    d.Status = true;
                });

            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(e => e.Departments, opt =>
                    opt.MapFrom(dto => dto.Departments
                        .Select(id => new DepartmentEmployee
                        { 
                            DepartmentId = id,
                            CreatedBy = dto.CreatedBy,
                            CreatedDate = DateTime.Now,
                            Status = true
                        })))
                .AfterMap((dto, e) =>
                {
                    e.CreatedDate = DateTime.Now;
                    e.Status = true;
                    e.Age = GetAge(dto.Birthdate);
                });

            CreateMap<UpdateDepartmentDto, Department>()
                .ForMember(d => d.Employees, opt => opt.Ignore())
                .AfterMap((dto,d)=> {
                    //Remove employees
                    var removedEmployees = d.Employees
                        .Where(e => !dto.Employees.Contains(e.EmployeeId))
                        .ToList();
                    foreach (var re in removedEmployees)
                        d.Employees.Remove(re);

                    //Add new employees
                    var addedEmployees = dto.Employees
                        .Where(id => !d.Employees.Any(e => e.EmployeeId == id))
                        .Select(id => new DepartmentEmployee { 
                            EmployeeId =id
                            , CreatedBy=d.CreatedBy
                            ,CreatedDate = d.CreatedDate
                            ,ModifiedBy = dto.ModifiedBy
                            ,ModifiedDate = DateTime.Now
                            ,Status = dto.Status
                        }).ToList();
                    foreach (var e in addedEmployees)
                        d.Employees.Add(e);
                    d.ModifiedDate = DateTime.Now;
                });

            CreateMap<UpdateEmployeeDto, Employee>()
                .ForMember(e => e.Departments, opt => opt.Ignore())
                .AfterMap((dto, e) => {
                    //Remove departments
                    var removedDepartments = e.Departments
                        .Where(d => !dto.Departments.Contains(d.DepartmentId))
                        .ToList();
                    foreach (var rd in removedDepartments)
                        e.Departments.Remove(rd);

                    //Add new departments
                    var addedDepartments = dto.Departments
                        .Where(id => !e.Departments.Any(d => d.DepartmentId == id))
                        .Select(id => new DepartmentEmployee { 
                            DepartmentId= id
                            ,CreatedBy=e.CreatedBy
                            ,CreatedDate = e.CreatedDate
                            ,ModifiedBy = dto.ModifiedBy
                            ,ModifiedDate = DateTime.Now
                            ,Status = dto.Status
                        }).ToList();
                    foreach (var d in addedDepartments)
                        e.Departments.Add(d);
                    e.ModifiedDate = DateTime.Now;                    
                    e.Age = GetAge(dto.Birthdate);
                });
        }

        private static int GetAge(DateTime? birthdate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthdate.Value.Year;
            if (birthdate.Value.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}