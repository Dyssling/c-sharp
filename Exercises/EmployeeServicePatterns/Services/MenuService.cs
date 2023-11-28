using EmployeeServicePatterns.Models;

namespace EmployeeServicePatterns.Services
{
    public interface IMenuService
    {
        void Menu();
    }

    public class MenuService : IMenuService
    {
        public void Menu()
        {
            var employees = new List<Employee>();
            bool run = true;
            while (run == true)
            {
                Console.Clear();
                Console.WriteLine("1: Lägg till anställd.");
                Console.WriteLine("2: Avsluta.");
                foreach (Employee employee in employees)
                {
                    Console.WriteLine($"Namn: {employee.Name}  Position: {employee.Position}");
                }
                switch (Console.ReadLine())
                {
                    case "1":
                        var addEmployee = new EmployeeService();
                        employees.Add(addEmployee.AddEmployee());
                        break;
                    case "2":
                        run = false;
                        break;

                }
            }
        }
    }
}
