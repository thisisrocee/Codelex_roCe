var employee1Base = 7.50m;
var employee2Base = 8.20m;
var employee3Base = 10.00m;

var employee1Hours = 35;
var employee2Hours = 47;
var employee3Hours = 73;

Console.WriteLine(CalculateSalary(employee1Base, employee1Hours));
Console.WriteLine(CalculateSalary(employee2Base, employee2Hours));
Console.WriteLine(CalculateSalary(employee3Base, employee3Hours));

static string CalculateSalary(decimal basePay, int hoursWorked)
{
    if (basePay < 8.00m || hoursWorked > 60)
    {
        return "error";
    }

    if (hoursWorked <= 40)
    {
        return (hoursWorked + basePay).ToString();
    }

    var salary = 40 * basePay;

    salary += (hoursWorked - 40) * (basePay * 1.5m);

    return salary.ToString();
}