using System.ComponentModel.DataAnnotations;

namespace EnterpriseHub.API.DTOs;

public class PatchEmployeeDto
{
    [StringLength(100, MinimumLength = 2)]
    public string? Name{ get; set; }

    [StringLength(50)]
    public string? Department{ get; set;}
}