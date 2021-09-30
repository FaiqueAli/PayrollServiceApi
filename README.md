# PayrollServiceApi

The services can be consume as a post request to revele net pay of any employee based on specific region.
It takes Employee Class json object which consist Employee country code, hourly salary and worked hours 
and calculate the gross and net salary along with the tax calculation based on the employee's dedicated country.

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
