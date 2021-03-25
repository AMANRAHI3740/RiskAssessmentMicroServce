using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskAssessment.Models
{
    public class CollateralRisk
    {
        public double RiskPercentage { get; set; }
        public DateTime DateAssessed { get; set; }

        public CollateralRisk()
        {

        }
        public CollateralRisk(double riskPercentage,DateTime dateAssessed)
        {
            this.RiskPercentage = riskPercentage;
            this.DateAssessed = dateAssessed;
        }
    }
}
