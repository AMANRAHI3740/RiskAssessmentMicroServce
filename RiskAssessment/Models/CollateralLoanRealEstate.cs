using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskAssessment.Models
{
    public class CollateralLoanRealEstate
    {
        public int LoanId { get; set; }
        public int CollateralId { get; set; }
        public DateTime PledgedDate { get; set; }
        public int CustomerID { get; set; }
        public string OwnerName { get; set; }
        public string OwnerDetails { get; set; }
        public string CollateralType { get; set; }
        public long CurrentValue { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public string AddressOfProperty { get; set; }
        public long RatePerSqFt { get; set; }
        public long DepreciationRate { get; set; }
    }
}
