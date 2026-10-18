using System.ComponentModel.DataAnnotations;

namespace EnterpriseHub.API.DTOs;

public class CreateEmployeeDto
{
    [Required(ErrorMessage = "Employee name is required.")]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Department is required.")]
    [StringLength(50)]
    public string Department { get; set; } = string.Empty;
}