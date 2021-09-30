using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollServiceApi.Model
{
    public class EmployeeSalary
    {
        public string countryCode { get; set; }
        public double grossSalary { get; set; }
        public double netSalary { get; set; }
        public double salaryTax { get; set; }
    }
}