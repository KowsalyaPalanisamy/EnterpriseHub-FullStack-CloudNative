using EnterpriseHub.API.Models;

namespace EnterpriseHub.API.Models;
public class Department
{
    public int Id { get; set; }
    public string Name { get; set;} = string.Empty;

    //ICollections - Can use different collection implementations means, now new List<Employee>() LATER new HashSet<Employee>(); such as dictionary, etc. But List is the most common implementation of ICollection.
    public ICollection<Employee> Employees { get; set;} = new List<Employee>();
}