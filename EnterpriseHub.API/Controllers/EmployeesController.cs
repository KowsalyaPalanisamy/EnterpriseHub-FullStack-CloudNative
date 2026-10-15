using Microsoft.AspNetCore.Mvc;

namespace EnterpriseHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    [HttpGet(Name = "GetEmployees")]
    public IActionResult GetEmployees()
    {
        var employees = new[]{
            new { Id = 1, Name = "John Doe", Department = "IT" },
            new { Id = 2, Name = "Emily Davis", Department = "HR" },
            new { Id = 3, Name = "David Wilson", Department = "Finance" }
        };
        return Ok(employees);
    }
}