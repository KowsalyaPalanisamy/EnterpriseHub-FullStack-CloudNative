using EnterpriseHub.API.Models;
using EnterpriseHub.API.DTOs;

namespace EnterpriseHub.API.Services;

public interface IEmployeeService{
    IEnumerable<Employee> GetAllEmployees();
    Employee? GetEmployeeById(int id);
    Employee Create(CreateEmployeeDto dto);
    bool Update(int id, UpdateEmployeeDto dto);
    bool Patch(int id, PatchEmployeeDto dto);
    bool Delete(int id);
}