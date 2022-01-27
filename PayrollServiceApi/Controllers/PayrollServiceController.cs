using PayrollServiceApi.Data;
using PayrollServiceApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PayrollServiceApi.Controllers
{
    [Route("api/PayrollService/{action}")]
    public class PayrollServiceController : ApiController
    {
        private readonly IEmployeeSalary _repository;

        public PayrollServiceController(IEmployeeSalary repository)
        {
            _repository = repository;
        }
        [HttpPost]
        //https://localhost:44330/api/Payrollservice/countryCode
        public IHttpActionResult countryCode(Employee employee)
        {
            EmployeeSalary empPayroll;

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            empPayroll = _repository.SalaryDetails(employee);
            if (empPayroll == null)
                return BadRequest();
            else
                return Ok(empPayroll);
        }
        [HttpGet]
        //https://localhost:44330/api/Payrollservice/GetTaxRegons
        public IHttpActionResult GetTaxRegons()
        {
            return Ok(_repository.GetAllTaxRegion());

        }
    }
}
