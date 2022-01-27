using PayrollServiceApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollServiceApi.Data
{
    public class MockEmployeeSalary : IEmployeeSalary
    {
        List<TaxRegion> lsRegions = new List<TaxRegion>{
            new TaxRegion{
                country="Spain", countryCode="SPN",primaryTaxAmountRange=600,primaryTaxPercentage=0.25,secondaryTaxPercentage=0.4,socialContributionPercentage=0.04,
                primarySocialChargeAmountRange=500,primarySocialChargePercentage=0.07,secondarySocialChargePercentage=0.08 },

            new TaxRegion{
                country="Italy", countryCode="ITL",primaryTaxAmountRange=0,primaryTaxPercentage=0.25,secondaryTaxPercentage=0,socialContributionPercentage=0.09,
                primarySocialChargeAmountRange=0,primarySocialChargePercentage=0,secondarySocialChargePercentage=0 },

            new TaxRegion{
                country="Germany", countryCode="DEU",primaryTaxAmountRange=400,primaryTaxPercentage=0.25,secondaryTaxPercentage=0.32,socialContributionPercentage=0.02,
                primarySocialChargeAmountRange=0,primarySocialChargePercentage=0,secondarySocialChargePercentage=0 }

            };

        public List<TaxRegion> GetAllTaxRegion()
        {
            var lsRegons = lsRegions.ToList();
            return lsRegons;
        }

        public EmployeeSalary SalaryDetails(Employee employee)
        {
            double salaryAmount;
            double salaryTax;

            //check required parameters
            if (lsRegions.Count(x => x.countryCode == employee.countryCode) > 0 && employee.hourseWorked > 0 && employee.hourlyRate > 0)
            {
                salaryAmount = employee.hourlyRate * employee.hourseWorked;
                salaryTax    = SalaryTax(employee.countryCode, salaryAmount);

                EmployeeSalary employeeSalary = new EmployeeSalary() 
                {
                    countryCode = employee.countryCode,
                    grossSalary = salaryAmount,
                    netSalary = salaryAmount - salaryTax,
                    salaryTax = salaryTax
                };

                return employeeSalary;
            }
            else
            {
                return null;
            }
        }

        public double SalaryTax(string countryCode, double salaryAmount)
        {
            double initialTax;
            double progressiveTax;
            double initialContributionTax;
            double progressiveContributionTax;
            double socialContribution;
            try
            {
                var lsCountry = lsRegions.FirstOrDefault(x => x.countryCode == countryCode);

                //for all region
                socialContribution = salaryAmount * lsCountry.socialContributionPercentage;
                initialTax = (salaryAmount <= lsCountry.primaryTaxAmountRange || lsCountry.primaryTaxAmountRange == 0) ? salaryAmount * lsCountry.primaryTaxPercentage : lsCountry.primaryTaxAmountRange * lsCountry.primaryTaxPercentage;

                //for SPN and DEU
                progressiveTax = (salaryAmount > lsCountry.primaryTaxAmountRange && lsCountry.primaryTaxAmountRange != 0) ? (salaryAmount - lsCountry.primaryTaxAmountRange) * lsCountry.secondaryTaxPercentage : 0;

                //for SPN 
                initialContributionTax = (salaryAmount <= lsCountry.primarySocialChargeAmountRange && lsCountry.primarySocialChargeAmountRange != 0) ? salaryAmount * lsCountry.primarySocialChargePercentage : lsCountry.primarySocialChargeAmountRange * lsCountry.primarySocialChargePercentage;
                progressiveContributionTax = (salaryAmount > lsCountry.primarySocialChargeAmountRange && lsCountry.primarySocialChargeAmountRange != 0) ? (salaryAmount - lsCountry.primarySocialChargeAmountRange) * lsCountry.secondarySocialChargePercentage : 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
            return socialContribution + initialTax + progressiveTax + initialContributionTax + progressiveContributionTax;
        }
    }
}