using EmployeeServicePatterns.Models;

namespace EmployeeServicePatterns.Services
{
    public interface IEmployeeService
    {
        Employee AddEmployee();

    }

    public class EmployeeService : IEmployeeService
    {
        public Employee AddEmployee()
        {
            Console.Write("Anställdes namn: ");
            string name = Console.ReadLine()!;

            Console.Write("Anställdes position: ");
            string position = Console.ReadLine()!;

            return (new Employee(name, position));
        }
    }
}
