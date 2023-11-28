namespace EmployeeServicePatterns.Models
{
    public class Employee
    {
        public Employee(string name, string position)
        {
            Name = name;
            Position = position;
        }
        public string? Name { get; set; }
        public string? Position { get; set; }
    }
}
