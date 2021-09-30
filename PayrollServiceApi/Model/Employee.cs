using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollServiceApi.Model
{
    public class Employee
    {
        public string countryCode { get; set; }
        public double hourlyRate { get; set; }
        public double hourseWorked { get; set; }
    }
}