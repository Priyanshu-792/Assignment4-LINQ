# Assignment: LINQ Tasks

## Task Descriptions

### Task 1: Print Total Salary of All Employees

**Requirement**: Calculate the total salary of all employees and print their corresponding names in ascending order of their salary.

### Task 2: Print Employee Details of 2nd Oldest Employee

**Requirement**: Find the second oldest employee and print their details, including their total monthly salary.

### Task 3: Print Means of Monthly, Performance, Bonus Salary

**Requirement**: Calculate the means of monthly, performance, and bonus salary for employees whose age is greater than 30, and print them.

## Implementation Explanation

Each task is completed using LINQ queries in C#. Here's how each task is implemented:

1. **Task 1**: LINQ query is used to join employee and salary lists, grouping by employee name and summing up salary amounts. The result is ordered by total salary in ascending order, and then printed with employee names and total salary.

2. **Task 2**: LINQ query orders employees by age in descending order, skips the first employee (oldest), and takes the second employee (second oldest). Then, another LINQ query is used to find the salary details of the second oldest employee and print their details.

3. **Task 3**: LINQ query filters employees whose age is greater than 30, joins with salary list, groups by salary type, and calculates the mean salary for each type. The means are then printed.

This README explains the requirements and approach to completing the tasks using LINQ in C#.
