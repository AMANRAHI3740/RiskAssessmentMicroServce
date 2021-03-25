using Microsoft.AspNetCore.Mvc;
using RiskAssessment.Models;
using RiskAssessment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RiskAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskAssessment : ControllerBase
    {

        private readonly IRiskCalculator RiskCalculator;
        public RiskAssessment(IRiskCalculator riskCalculator)
        {
            RiskCalculator = riskCalculator;
        }
        // GET: RiskAssessment/Details/5
        [HttpGet("CD")]
        public ActionResult GetCollateralRiskCD(int loanId)
        {

            if (loanId < 0)
            {
                return this.BadRequest("Invalid ID");
            }
            CollateralLoanCashDeposit collateralLoanCashDeposit = new CollateralLoanCashDeposit();
            CollateralRisk collateralRisk = new CollateralRisk();
            try
            {
                if (loanId > 100 && loanId <= 199)
                {    
                    collateralLoanCashDeposit = RiskCalculator.GetCollateralRiskCD(loanId).Result;
                    if (collateralLoanCashDeposit != null)
                    {
                        double marketValue = collateralLoanCashDeposit.CurrentValue + (collateralLoanCashDeposit.InterestRate * collateralLoanCashDeposit.CurrentValue) / 100;
                        if (collateralLoanCashDeposit.CurrentValue <= marketValue)
                        {
                            collateralRisk.RiskPercentage = (Math.Abs(collateralLoanCashDeposit.CurrentValue - marketValue) * 100) / collateralLoanCashDeposit.CurrentValue;
                            collateralRisk.DateAssessed = collateralLoanCashDeposit.PledgedDate;
                        }
                        else
                        {
                            collateralRisk.RiskPercentage = 0;
                        }
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return NoContent();
                }
                return Ok(collateralRisk);   
            }
            catch(Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpGet("RE")]
        public ActionResult GetCollateralRiskRE(int loanId)
        {

            if (loanId < 0)
            {
                return this.BadRequest("Invalid ID");
            }
            CollateralLoanRealEstate collateralLoanRealEstate = new CollateralLoanRealEstate();
            CollateralRisk collateralRisk = new CollateralRisk();
            try
            {
                if (loanId > 200 && loanId <= 299)
                {
                    collateralLoanRealEstate = RiskCalculator.GetCollateralRiskRE(loanId).Result;
                    if (collateralLoanRealEstate != null)
                    {
                        TimeSpan dateDifference = DateTime.Now - collateralLoanRealEstate.DateOfPurchase;
                        double days = dateDifference.TotalDays;
                        long diff = Convert.ToInt64(days) / 365;
                        long marketValue = collateralLoanRealEstate.CurrentValue + (collateralLoanRealEstate.DepreciationRate * collateralLoanRealEstate.CurrentValue * diff) / 100;

                        if (collateralLoanRealEstate.CurrentValue <= marketValue)
                        {
                            collateralRisk.RiskPercentage = (Math.Abs(collateralLoanRealEstate.CurrentValue - marketValue) * 100) / collateralLoanRealEstate.CurrentValue;
                            collateralRisk.DateAssessed = collateralLoanRealEstate.PledgedDate;
                        }
                        else
                        {
                            collateralRisk.RiskPercentage = 0;
                        }
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return NoContent();
                }
                return Ok(collateralRisk);
            }
            catch(Exception e)
            {
                 return this.BadRequest(e.Message);
            }
        }           
    }
}

