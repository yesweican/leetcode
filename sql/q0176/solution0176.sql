/*won't work for less than 2 records*/
select Salary as SecondHighestSalary from (select Salary from Employee order by Salary desc limit 2) as TopSalaries order by Salary limit 1;


/*won't work if there are ties*/
select Max(Salary) as SecondHighestSalary from Employee where Salary< (select Max(Salary) from Employee);
