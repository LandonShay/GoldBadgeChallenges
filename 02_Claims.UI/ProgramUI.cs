using _02_Claims.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims.UI
{
    public class ProgramUI
    {
        private readonly ClaimsRepository _claimsRepo;
        public void Run()
        {
            RunApplication();
        }

        public ProgramUI()
        {
            _claimsRepo = new ClaimsRepository();
        }
        public void RunApplication()
        {
            bool keepLooping = true;
            while (keepLooping == true)
            {
                Console.Clear();
                Console.WriteLine("Komodo Claims\n" +
                    "1. View All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Add New Claim");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            }
        }
        public void ViewAllClaims()
        {
            Console.Clear();
            DisplayClaimDetails();
            Console.ReadKey();
        }

        public void ViewQueue()
        {
            Console.Clear();
            Claims claim = _claimsRepo.SeeWhoIsNextInQueue();
            Console.WriteLine(claim.ToString());
        }

        public void TakeCareOfNextClaim()
        {
            Console.Clear();
            ViewQueue();
            Console.WriteLine("Do you want to deal with this claim now? y/n");
            string response = Console.ReadLine();
            if (response == "y")
            {
                _claimsRepo.DequeueClaim();
            }
        }

        public void AddNewClaim()
        {
            Claims claim = new Claims();
            Queue queue = new Queue();  
            Console.Clear();
            Console.WriteLine("Is claim a:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            int claimType = int.Parse(Console.ReadLine());
            claim.ClaimType = (ClaimType)claimType;
            Console.WriteLine("Enter claim description");
            claim.Description = Console.ReadLine();
            Console.WriteLine("Enter claim amount");
            claim.ClaimAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter date of accident yyyy/mm/dd");
            claim.DateOfIncident = DateTime.Parse(Console.ReadLine()); //Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter date of claim yyyy/mm/dd");
            claim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            _claimsRepo.AddNewClaim(claim);
        }

        public void DisplayClaimDetails()
        {
            Queue<Claims> claims = _claimsRepo.SeeAllClaims();
            foreach (Claims claim in claims)
                Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.ClaimType}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Claim Amount: {claim.ClaimAmount}\n" +
                    $"Date of Accident: {claim.DateOfIncident}\n" +
                    $"Date Claimed: {claim.DateOfClaim}\n" +
                    $"Is Valid: {claim.IsValid}");
        }
    }
}
