using _04_Outings.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _04_Outings.Repository.Outings;

namespace _04_Outings.UI
{
    public class ProgramUI
    {
        private readonly OutingsRepository _outingsRepo;

        public ProgramUI()
        {
            _outingsRepo = new OutingsRepository();
        }

        public void Run()
        {
            Seed();
            RunApplication();
        }

        public void RunApplication()
        {
            bool keepLooping = true;
            while (keepLooping == true)
            {
                Console.Clear();
                Console.WriteLine("Outings Database\n" +
                    "1. Add New Outing\n" +
                    "2. View All Outings\n" +
                    "3. Outing Calculations");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddNewOuting();
                        break;
                    case "2":
                        ViewAllOutings();
                        break;
                    case "3":
                        OutingCalculations();
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }
            }
        }

        public void AddNewOuting()
        {
            Console.Clear();
            Outings outing = new Outings();
            Console.WriteLine("Select type of outing\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");
            int eventType = int.Parse(Console.ReadLine());
            outing.Event = (EventType)eventType;
            Console.WriteLine("Insert number of people that attended event");
            outing.NumberOfAttendees = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the date the event took place yyyy/mm/dd");
            outing.Date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter the total cost per person for the event");
            outing.TotalCostPerPerson = double.Parse(Console.ReadLine());

            _outingsRepo.AddNewOuting(outing);
        }

        public void ViewAllOutings()
        {
            Console.Clear();
            List<Outings> outings = _outingsRepo.ViewAllOutings();
            foreach (var outing in outings)
            {
                Console.WriteLine($"Event Type: {outing.Event}\n" +
                    $"Date of Event: {outing.Date}\n" +
                    $"Number of Attendees: {outing.NumberOfAttendees}\n" +
                    $"Total cost per person: ${outing.TotalCostPerPerson}\n" +
                    $"Total cost per event: ${outing.TotalCostForEvent}\n" +
                    $"");
            }
            Console.ReadKey();
        }

        public void OutingCalculations()
        {
            Console.Clear();
            Console.WriteLine($"Total cost of all outings: ${GetTotalCost()}\n" +
                $"Total cost of all Golf outings: ${GetTotalCostOfCertainEvents((EventType)1)}\n" +
                $"Total cost of all Bowling outings: ${GetTotalCostOfCertainEvents((EventType)2)}\n" +
                $"Total cost of all Amusement Park outings: ${GetTotalCostOfCertainEvents((EventType)3)}\n" +
                $"Total cost of all Concert outings: ${GetTotalCostOfCertainEvents((EventType)4)}");
            Console.ReadKey();
        }

        public double GetTotalCost()
        {
            List<Outings> outings = _outingsRepo.ViewAllOutings();
            double totalCost = 0;
            foreach (var outing in outings)
            {
                totalCost += outing.TotalCostForEvent;
            }
            return totalCost;
        }

        public double GetTotalCostOfCertainEvents(EventType eventType)
        {
            List<Outings> outings = _outingsRepo.ViewAllOutings();
            double totalCost = 0;
            foreach (var outing in outings)
            {
                if (outing.Event == eventType)
                {
                    totalCost += outing.TotalCostForEvent;
                }
            }
            return totalCost;
        }

        public void Seed()
        {
            Outings outing = new Outings();
            outing.Event = (EventType)1;
            outing.NumberOfAttendees = 20;
            outing.TotalCostPerPerson = 26;
            outing.Date = DateTime.Now;

            Outings outing2 = new Outings();
            outing2.Event = (EventType)1;
            outing2.NumberOfAttendees = 40;
            outing2.TotalCostPerPerson = 14;
            outing2.Date = DateTime.Now;

            Outings outing3 = new Outings();
            outing3.Event = (EventType)2;
            outing3.NumberOfAttendees = 202;
            outing3.TotalCostPerPerson = 46;
            outing3.Date = DateTime.Now;

            Outings outing4 = new Outings();
            outing4.Event = (EventType)2;
            outing4.NumberOfAttendees = 67;
            outing4.TotalCostPerPerson = 23;
            outing4.Date = DateTime.Now;

            Outings outing5 = new Outings();
            outing5.Event = (EventType)3;
            outing5.NumberOfAttendees = 64;
            outing5.TotalCostPerPerson = 76;
            outing5.Date = DateTime.Now;

            Outings outing6 = new Outings();
            outing6.Event = (EventType)3;
            outing6.NumberOfAttendees = 87;
            outing6.TotalCostPerPerson = 87;
            outing6.Date = DateTime.Now;

            Outings outing7 = new Outings();
            outing7.Event = (EventType)4;
            outing7.NumberOfAttendees = 45;
            outing7.TotalCostPerPerson = 54;
            outing7.Date = DateTime.Now;

            Outings outing8 = new Outings();
            outing8.Event = (EventType)4;
            outing8.NumberOfAttendees = 20;
            outing8.TotalCostPerPerson = 26;
            outing8.Date = DateTime.Now;

            _outingsRepo.AddNewOuting(outing);
            _outingsRepo.AddNewOuting(outing2);
            _outingsRepo.AddNewOuting(outing3);
            _outingsRepo.AddNewOuting(outing4);
            _outingsRepo.AddNewOuting(outing5);
            _outingsRepo.AddNewOuting(outing6);
            _outingsRepo.AddNewOuting(outing7);
            _outingsRepo.AddNewOuting(outing8);
        }
    }
}

/*Calculations:

They'd like to see a display for the combined cost for all outings.
They 'd like to see a display of outing costs by type.
For example, all bowling outings for the year were $2000.00. All Concert outings cost $5000.00.*/

