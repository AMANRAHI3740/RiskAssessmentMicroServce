using RiskAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskAssessment.Services
{
    public interface IRiskCalculator
    {
        public Task<CollateralLoanCashDeposit> GetCollateralRiskCD(int loanId);
        public Task<CollateralLoanRealEstate> GetCollateralRiskRE(int loanId);
    }
}
