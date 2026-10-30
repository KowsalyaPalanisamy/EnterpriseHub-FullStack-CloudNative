
namespace EnterpriseHub.API.Models;

public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Department { get; set; } = string.Empty;

    public decimal Salary { get; set; }

    public int? DepartmentId { get; set; }

    public Department? DepartmentDetails { get; set; }

}
