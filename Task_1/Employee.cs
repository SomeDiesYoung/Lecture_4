
internal class Employee
{
    private string name;
    private int hourlyWage;
    private TimeSpan hoursWorked;

    public Employee(string name, int hourlyWage, TimeSpan hoursWorked)
    {
        this.name = name;
        this.hourlyWage = hourlyWage;
        this.hoursWorked = hoursWorked;
    }
}