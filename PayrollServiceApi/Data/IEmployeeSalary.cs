using PayrollServiceApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollServiceApi.Data
{
    public interface IEmployeeSalary
    {
        double SalaryTax(string countryCode, double salaryAmount);
        EmployeeSalary SalaryDetails(Employee employee);
    }
}
