using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings.Repository
{
    public class Outings
    {
        public enum EventType
        {
            Golf = 1,
            Bowling,
            AmusmentPark,
            Concert
        }
        public Outings()
        {

        }

        public Outings(int numberOfAttendees, DateTime date, double totalCostPerPerson, double totalCostForEvent, EventType eventType)
        {
            numberOfAttendees = NumberOfAttendees;
            date = Date;
            totalCostPerPerson = TotalCostPerPerson;
            totalCostForEvent = TotalCostForEvent;
            eventType = Event;
        }

        public int NumberOfAttendees { get; set; }
        public DateTime Date { get; set; }
        public double TotalCostPerPerson { get; set; }
        public double TotalCostForEvent 
        {
            get
            {
                double sum = NumberOfAttendees * TotalCostPerPerson;
                return sum;
            }
        }
        public EventType Event { get; set; }
    }
}