using PayrollServiceApi.Data;
using PayrollServiceApi.Model;
using System;
using Xunit;

namespace PayrollServiceUnitTest
{
    public class PayrollServiceApiTest
    {
        Employee employee = new Employee() { hourlyRate = 10, hourseWorked = 20 };
        MockEmployeeSalary mockEmployee = new MockEmployeeSalary();
        double expectedSalaryTax ;
        double actualSalaryTax;

        [Fact]
        public void Check_German_Employee_Salar_Tax()
        {
            //Arrange
            employee.countryCode = "DEU";
            expectedSalaryTax = 54;
            //Act
            actualSalaryTax = mockEmployee.SalaryTax(employee.countryCode, employee.hourlyRate * employee.hourseWorked);

            //Assert
            Assert.Equal(expectedSalaryTax, actualSalaryTax);
        }
        [Fact]
        public void Check_Spanish_Employee_Salar_Tax()
        {
            //Arrange
            employee.countryCode = "SPN";
            expectedSalaryTax = 72;
            //Act
            actualSalaryTax = mockEmployee.SalaryTax(employee.countryCode, employee.hourlyRate * employee.hourseWorked);

            //Assert
            Assert.Equal(expectedSalaryTax, actualSalaryTax);
        }
        [Fact]
        public void Check_Italian_Employee_Salar_Tax()
        {
            //Arrange
            employee.countryCode = "ITL";
            expectedSalaryTax = 68;

            //Act
            actualSalaryTax = mockEmployee.SalaryTax(employee.countryCode, employee.hourlyRate * employee.hourseWorked);

            //Assert
            Assert.Equal(expectedSalaryTax, actualSalaryTax);
        }
    }
}
