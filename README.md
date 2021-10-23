# PayrollServiceApi

The services can be consume as a post request to revele net pay of any employee based on specific region.
It takes Employee as a json object which consist Employee country code, hourly rate and worked hours 
and calculate the gross and net salary along with the tax calculation based on the employee's dedicated country.

Details of the salary calculation vary country  to country as follow..

1. As a payroll user, I would like to see a gross amount calculation for an employee’s salary. Given
the employee is paid €10 per hour, when the employee works 40 hours, the Gross amount is
€40.

2. As a payroll user, I would like to see deductions charged for employees located in Spain
Given the employee is located in Spain, income tax at a rate of 25% for the first €600 and 40%
thereafter (progressive tax*).

Given the employee is located in Spain, a Universal social charge of 7% is applied for the first
€500 euro and 8% thereafter (progressive tax*).

Given the employee is located in Spain, a compulsory pension contribution of 4% is applied.

5.As a payroll user, I would like to see deductions charged for employees located in Italy
Given the employee is located in Italy, income tax at a flat rate of 25% is applied
Given the employee is located in Italy, an INPS contribution of 9.19% is applied;

6. As a payroll user, I would like to see deductions charged for employees located in Germany
Given the employee is located in Germany, income tax at a rate of 25% is applied on the first
€400 and 32% thereafter (progressive tax*).
Given the employee is located in Germany, a compulsory pension contribution of 2% is applied.

It is created by Microsoft Webapi2 having dotnet framework 4.6.1 (C#)
sample of the post request is as follow.
{
    "hourseWorked":20,
    "hourlyRate":10,
    "countryCode": "DEU"
}
similarly, bellow is the output of the service 
{
    "$id": "1",
    "countryCode": "DEU",
    "grossSalary": 200.0,
    "netSalary": 146.0,
    "salaryTax": 54.0
}
I used UnitiyFramework for the dependency injection
the service also contains Unit test of this application which initially test the expected tax amount based on different countries.
