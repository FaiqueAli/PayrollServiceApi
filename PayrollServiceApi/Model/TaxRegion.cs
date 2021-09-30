using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollServiceApi.Model
{
    public class TaxRegion
    {
        public string country { get; set; }
        public string countryCode { get; set; }
        public int primaryTaxAmountRange { get; set; }
        public double primarySocialChargeAmountRange { get; set; }
        public double primaryTaxPercentage { get; set; }
        public double secondaryTaxPercentage { get; set; }
        public double primarySocialChargePercentage { get; set; }
        public double secondarySocialChargePercentage { get; set; }
        public double socialContributionPercentage { get; set; }
    }
}