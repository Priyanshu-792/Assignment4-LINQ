using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    IList<Employee> employeeList;
    IList<Salary> salaryList;

    public Program()
    {
        employeeList = new List<Employee>() {
            new Employee(){ EmployeeID = 1, EmployeeFirstName = "Rajiv", EmployeeLastName = "Desai", Age = 49},
            new Employee(){ EmployeeID = 2, EmployeeFirstName = "Karan", EmployeeLastName = "Patel", Age = 32},
            new Employee(){ EmployeeID = 3, EmployeeFirstName = "Sujit", EmployeeLastName = "Dixit", Age = 28},
            new Employee(){ EmployeeID = 4, EmployeeFirstName = "Mahendra", EmployeeLastName = "Suri", Age = 26},
            new Employee(){ EmployeeID = 5, EmployeeFirstName = "Divya", EmployeeLastName = "Das", Age = 20},
            new Employee(){ EmployeeID = 6, EmployeeFirstName = "Ridhi", EmployeeLastName = "Shah", Age = 60},
            new Employee(){ EmployeeID = 7, EmployeeFirstName = "Dimple", EmployeeLastName = "Bhatt", Age = 53}
        };

        salaryList = new List<Salary>() {
            new Salary(){ EmployeeID = 1, Amount = 1000, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 1, Amount = 500, Type = SalaryType.Performance},
            new Salary(){ EmployeeID = 1, Amount = 100, Type = SalaryType.Bonus},
            new Salary(){ EmployeeID = 2, Amount = 3000, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 2, Amount = 1000, Type = SalaryType.Bonus},
            new Salary(){ EmployeeID = 3, Amount = 1500, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 4, Amount = 2100, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 5, Amount = 2800, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 5, Amount = 600, Type = SalaryType.Performance},
            new Salary(){ EmployeeID = 5, Amount = 500, Type = SalaryType.Bonus},
            new Salary(){ EmployeeID = 6, Amount = 3000, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 6, Amount = 400, Type = SalaryType.Performance},
            new Salary(){ EmployeeID = 7, Amount = 4700, Type = SalaryType.Monthly}
        };
    }

    public static void Main()
    {
        Program program = new Program();

        program.Task1();

        program.Task2();

        program.Task3();
    }

    public void Task1()
    {
        var totalSalaries = from emp in employeeList
                            join sal in salaryList on emp.EmployeeID equals sal.EmployeeID
                            group sal.Amount by new { emp.EmployeeFirstName, emp.EmployeeLastName } into g
                            orderby g.Sum() ascending
                            select new { EmployeeName = $"{g.Key.EmployeeFirstName} {g.Key.EmployeeLastName}", TotalSalary = g.Sum() };

        Console.WriteLine("Total Salary of all employees with their corresponding names in ascending order of their salary:");
        foreach (var emp in totalSalaries)
        {
            Console.WriteLine($"{emp.EmployeeName}: {emp.TotalSalary}");
        }
        Console.WriteLine();
    }

    public void Task2()
    {
        var secondOldest = (from emp in employeeList
                                    orderby emp.Age descending
                                    select emp).Skip(1).FirstOrDefault();

        if (secondOldest != null)
        {
            var employeeSalary = (from sal in salaryList
                                  where sal.EmployeeID == secondOldest.EmployeeID
                                  group sal.Amount by sal.Type into g
                                  select new { SalaryType = g.Key, TotalSalary = g.Sum() });

            Console.WriteLine($"Employee details of 2nd oldest employee that is {secondOldest.EmployeeFirstName} {secondOldest.EmployeeLastName} is:");
            Console.WriteLine($"Age: {secondOldest.Age}");
            Console.WriteLine($"Total Monthly Salary: {employeeSalary.FirstOrDefault(s => s.SalaryType == SalaryType.Monthly)?.TotalSalary}");

            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("No employee found.");
        }
    }

    public void Task3()
    {
        var meanSalaries = (from emp in employeeList
                            where emp.Age > 30
                            join sal in salaryList on emp.EmployeeID equals sal.EmployeeID
                            group sal.Amount by sal.Type into g
                            select new { SalaryType = g.Key, MeanSalary = g.Average() });

        Console.WriteLine("Mean salaries of Monthly, Performance, Bonus for employees older than 30:");
        foreach (var salary in meanSalaries)
        {
            Console.WriteLine($"{salary.SalaryType}: {salary.MeanSalary}");
        }
        Console.WriteLine();
    }
}

public enum SalaryType
{
    Monthly,
    Performance,
    Bonus
}

public class Employee
{
    public int EmployeeID { get; set; }
    public string EmployeeFirstName { get; set; }
    public string EmployeeLastName { get; set; }
    public int Age { get; set; }
}

public class Salary
{
    public int EmployeeID { get; set; }
    public int Amount { get; set; }
    public SalaryType Type { get; set; }
}
