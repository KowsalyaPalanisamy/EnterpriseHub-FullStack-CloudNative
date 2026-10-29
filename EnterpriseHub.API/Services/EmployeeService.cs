using EnterpriseHub.API.DTOs;
using EnterpriseHub.API.Models;
using EnterpriseHub.API.Data;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseHub.API.Services;

public class EmployeeService : IEmployeeService
{
    private readonly EnterpriseHubDbContext _context;

    public EmployeeService(EnterpriseHubDbContext _dbcontext)
    {
        _context = _dbcontext;
    }
    //our Singleton service needed a lock to protect the shared in-memory list.
    // private readonly object _lock = new();

    // private readonly List<Employee> employees = new List<Employee>(){
    //     new Employee {Id = 1, Name = "Kowsi", Department = "IT", Salary = 75000},
    //     new Employee{Id = 2, Name = "Kowsalya", Department = "Merine", Salary = 80000},
    //     new Employee{Id = 3, Name = "Vidhya", Department = "IT", Salary = 70000}
    // };
    // private int nextId = 4;

    public IEnumerable<Employee> GetAllEmployees()
    {
        // lock(_lock)
        // {
        //     return employees.Select(Copy).ToList();
        // }

        return _context.Employees
            .AsNoTracking()
            .ToList();
    }

    public Employee? GetEmployeeById(int id)
    {
        // lock(_lock)
        // {
        //     var employee = employees.FirstOrDefault(e => e.Id == id);
        //     return employee is null ? null : Copy(employee);
        // }

        return _context.Employees
            .AsNoTracking()
            .FirstOrDefault(e=>e.Id == id);
    }

    public Employee Create(CreateEmployeeDto dto){
        // lock(_lock)
        // {
        //     var employee = new Employee
        //     {
        //         Id = nextId++,
        //         Name = dto.Name,
        //         Department = dto.Department
        //     };
        //     employees.Add(employee);
        //     return Copy(employee);
        // }

        var employee = new Employee{
            Name = dto.Name,
            Department = dto.Department
        };

        _context.Employees.Add(employee);
        _context.SaveChanges();

        return employee;

    }

    public bool Update(int id, UpdateEmployeeDto dto)
    {
        // lock(_lock)
        // {
        //     var employee = employees.FirstOrDefault(e => e.Id == id);
        //     if(employee == null){
        //         return false;
        //     }
        //     employee.Name = dto.Name;
        //     employee.Department = dto.Department;
        //     return true;
        // }

        // No AsNoTracking() here since we want to update the entity
        var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
        if(employee is null)
            return false;

        employee.Name = dto.Name;
        employee.Department = dto.Department;

        _context.SaveChanges();
        return true;
    }

    public bool Patch(int id, PatchEmployeeDto dto)
    {
        // lock(_lock)
        // {
        //     var employee = employees.FirstOrDefault(e => e.Id == id);
        //     if(employee == null)
        //     {
        //         return false;
        //     }
        //     if(dto.Name is not null)
        //     {
        //         employee.Name = dto.Name;
        //     }
        //     if(dto.Department is not null)
        //     {
        //         employee.Department = dto.Department;
        //     }
        //     return true;
        // }

        var employee = _context.Employees.FirstOrDefault(e => e.Id == id);

        if(employee is null)
            return false;
        if(dto.Name is not null)
        {
            employee.Name = dto.Name;
        }
        if(dto.Department is not null)
        {
            employee.Department = dto.Department;
        }

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id){
        // lock(_lock)
        // {
        //     var employee = employees.FirstOrDefault(e => e.Id == id);
        //     if(employee is null)
        //     {
        //         return false;
        //     }

        //     employees.Remove(employee);
        //     return true;
        // }

        var employee = _context.Employees.FirstOrDefault(e => e.Id == id);

        if(employee is null)
            return false;
        _context.Employees.Remove(employee);
        _context.SaveChanges();

        return true;
    }

    // private Employee Copy(Employee employee)
    // {
    //     return new Employee{
    //         Id = employee.Id,
    //         Name = employee.Name,
    //         Department = employee.Department,
    //         Salary = employee.Salary
    //     };
    // }
}