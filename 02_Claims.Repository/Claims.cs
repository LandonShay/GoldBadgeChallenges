using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims.Repository
{
    //Komodo allows an insurance claim to be made up to 30 days after an incident took place.
    //If the claim is not in the proper time limit, it is not valid.
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
    public class Claims
    {
        public Claims(int claimID,
            ClaimType claimType,
            string description,
            decimal claimAmount,
            DateTime dateOfIncident,
            DateTime dateOfClaim,
            bool isValid)
        {

        }

        public Claims()
        {

        }

        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid 
        {
            get
            {
                TimeSpan span = DateOfIncident - DateOfClaim;
                if (span.TotalDays > 30)
                {
                    return false;
                }
                return true;
            } 
        }

        public override string ToString()
        {
            return $"{ClaimID}\n" +
                $"{ClaimType}\n " +
                $"{Description}\n " +
                $"{ClaimAmount}\n" +
                $"{DateOfIncident}\n" +
                $"{DateOfClaim}\n" +
                $"{IsValid}\n";
        }
    }
}
