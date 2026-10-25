using Microsoft.AspNetCore.Mvc;
using EnterpriseHub.API.DTOs;
using EnterpriseHub.API.Models;
using EnterpriseHub.API.Services;

namespace EnterpriseHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }


    // private static readonly List<Employee> employees = new(){
    //     new Employee {Id = 1, Name = "John Doe", Department = "IT"},
    //     new Employee {Id = 2, Name = "Emily Davis", Department = "HR"},
    //     new Employee {Id = 3, Name = "David Wilson", Department = "Finance"}
    // };

    [HttpGet(Name = "GetEmployees")]
    public ActionResult<IEnumerable<Employee>> GetEmployees()
    {
        return Ok(_employeeService.GetAllEmployees());
    }


    [HttpGet("{id:int}")]
    public ActionResult<Employee> GetEmployeeByID(int id)
    {
        var employee = _employeeService.GetEmployeeById(id);
        //employees.FirstOrDefault(e => e.Id == id);

        if(employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPost]
    public ActionResult<Employee> CreateEmployee([FromBody] CreateEmployeeDto createEmployeeDto)
    {
        // var newEmployee = new Employee {
        //     Id = employees.Max(e => e.Id) + 1,
        //     Name = createEmployeeDto.Name,
        //     Department = createEmployeeDto.Department
        // };

        var newEmployee = _employeeService.Create(createEmployeeDto);

        // employees.Add(newEmployee);

        return CreatedAtAction(nameof(GetEmployeeByID), new {id = newEmployee.Id}, newEmployee);
    }


    [HttpPut("{id:int}")]
    public IActionResult UpdateEmployee(int id, [FromBody] UpdateEmployeeDto updateEmployeeDto)
    {
        //1. Find an employee by ID
        // var employee = employees.FirstOrDefault(e => e.Id == id);

        //2. If not fount, return NotFound()
        // if(employee == null)
        // {
        //     return NotFound();
        // }

        //3. Replace Employee's Name and Department with the values from updateEmployeeDto
        // employee.Name = updateEmployeeDto.Name;
        // employee.Department = updateEmployeeDto.Department;
        //4. return 204 No Content
        var updated = _employeeService.Update(id, updateEmployeeDto);
        if(!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpPatch("{id:int}")]
    public IActionResult PatchEmployee(int id, [FromBody] PatchEmployeeDto patchEmployeedto)
    {
        //1. Find en employee
        // var employee = employees.FirstOrDefault(e => e.Id == id);

        //2. if not return NotFount()
        // if(employee == null)
        // {
        //     return NotFound();
        // }

        //3. Update PatchDto values to Employee
        // if(patchEmployeedto.Name != null)
        // {
        //     employee.Name = patchEmployeedto.Name;
        // }

        // if(patchEmployeedto.Department != null)
        // {
        //     employee.Department = patchEmployeedto.Department;
        // }

        //4. Return 204 No Content
        var updated = _employeeService.Patch(id, patchEmployeedto);
        if(!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteEmployee(int id)
    {
        // var employee = employees.FirstOrDefault(e => e.Id == id);

        // if(employee == null)
        // {
        //     return NotFound();
        // }

        // employees.Remove(employee);
        var deleted = _employeeService.Delete(id);
        if(!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}