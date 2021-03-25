using RiskAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiskAssessment.Services
{
    public class RiskCalculator : IRiskCalculator
    {
        private IHttpClientFactory _httpClientFactory;
        public RiskCalculator(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<CollateralLoanCashDeposit> GetCollateralRiskCD(int loanId)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("http://localhost:55759");
            HttpResponseMessage res = httpClient.GetAsync("https://collateralmanagmentmicroservice.azurewebsites.net/api/CollateralLoan/CashDeposits?loanId=" + loanId).Result;
            CollateralLoanCashDeposit collateralLoanCashDeposit = await res.Content.ReadAsAsync<CollateralLoanCashDeposit>();
            return collateralLoanCashDeposit;
        }
        public async Task<CollateralLoanRealEstate> GetCollateralRiskRE(int loanId)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("http://localhost:55759");
            HttpResponseMessage res = httpClient.GetAsync("https://collateralmanagmentmicroservice.azurewebsites.net/api/CollateralLoan/RealEstates?loanId=" + loanId).Result;
            CollateralLoanRealEstate collateralLoanRealEstate = await res.Content.ReadAsAsync<CollateralLoanRealEstate>();
            return collateralLoanRealEstate;
        }
        
    }
}
