using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmbracoAssignment.CustomDatabase.Entities;
using UmbracoAssignment.Models;

namespace UmbracoAssignment.Helper
{
    public class EntityModelConverter
    {
        public static EmployeeModel ConvertEmployeToEmployeeModel(Employees employee) => new EmployeeModel
        {
            Id = employee.Id,
            Name = employee.Name,
            Email = employee.Email,
            DoB = employee.DoB,
        };

        public static Employees ConvertEmployeModelToEmployee(EmployeeModel employeeModel) => new Employees
        {
            Id = employeeModel.Id,
            Name = employeeModel.Name,
            Email = employeeModel.Email,
            DepartmentId = employeeModel.DepartmentId,
            DoB = employeeModel.DoB,
        };

        public static Department ConvertDepartmentModelToDepartment(DepartmentModel departmentModel) => new Department
        {
            Id = departmentModel.Id,
            Description = departmentModel.Description,
            Name = departmentModel.Name
        };

        public static DepartmentModel ConvertDepartmentModelToDepartment(Department department) => new DepartmentModel
        {
            Id = department.Id,
            Description = department.Description,
            Name = department.Name
        };
    }
}