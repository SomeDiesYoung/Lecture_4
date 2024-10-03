
public class Employees
{
    public string Name { get; private set; }
    public decimal HourlyWage { get; private set; }
    public TimeSpan HoursWorked { get; private set; }

    public Employees(string name, decimal hourlyWage, TimeSpan hoursWorked)
    {
        Name = name;
        HourlyWage = hourlyWage;
        HoursWorked = hoursWorked;
    }

    public decimal GetTotalEarnings()
    {
        return (decimal)Math.Min(HoursWorked.TotalHours, 8) * HourlyWage
               + (decimal)Math.Max(HoursWorked.TotalHours - 8, 0) * HourlyWage * 1.25m;
    }

    public bool HasOvertime()
    {
        return HoursWorked.TotalHours > 8;
    }

    public decimal GetOvertimeEarnings()
    {
        return (decimal)Math.Max(HoursWorked.TotalHours - 8, 0) * HourlyWage * 1.25m;
    }
}

public class EmployeesManager
{
    private readonly List<Employees> employees = new List<Employees>();

    public void AddEmployee()
    {
        var Name = GetEmployeeNameFromConsole();
        decimal HourlyWage = 100;  

        Random random = new Random();
        TimeSpan HoursWorked = new TimeSpan(random.Next(6, 12), 0, 0); 

        var employee = new Employees(Name, HourlyWage, HoursWorked);
        employees.Add(employee);
    }

    private string GetEmployeeNameFromConsole()
    {
        Console.WriteLine("Sheiyvanet Tanamshromelis saxeli:");
        return Console.ReadLine();
    }

    public void DisplayEmployees()
    {
        foreach (var employee in employees)
        {
            Console.WriteLine($"Saxeli: {employee.Name}, saatobrivi anazgaureba: {employee.HourlyWage}, Namushevari saatebi: {employee.HoursWorked.TotalHours}");
            Console.WriteLine($"Jamuri anazgaureba: {employee.GetTotalEarnings()}");

            if (employee.HasOvertime())
            {
                Console.WriteLine($"zeganakveturi anazgaureba: {employee.GetOvertimeEarnings()}");
            }

        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        EmployeesManager manager = new EmployeesManager();


        while (true)
        {
            manager.AddEmployee();
            Console.WriteLine("Gsurt employees damateba? (Yes/No)");

            string response = Console.ReadLine().ToLower();
            if(response != "yes")
            {
                break;
            }
        }
        manager.DisplayEmployees();
    }
}