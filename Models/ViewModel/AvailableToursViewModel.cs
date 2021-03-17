using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models.ViewModel
{
    public class AvailableToursViewModel
    {
        //Db Context
        private TempleAppointmentContext context { get; set; }

        public AvailableTimes Times = new AvailableTimes();
        public IEnumerable<string> AppointmentsMade { get; set; }
        //Constructor
        public AvailableToursViewModel (DateTime times, TempleAppointmentContext con)
        {
            Times.Date = times;
            context = con;
            AppointmentsMade = ScheduledAppointments();
        }

        //Get a list of appointment times for that day
        public IEnumerable<string> ScheduledAppointments()
        {

            List<string> myList = new List<string>();

            foreach (var x in context.Appointments)
            {
                if (x.AppointmentTime.DayOfYear == Times.Date.DayOfYear)
                {
                    myList.Add(Convert.ToString(x.AppointmentTime.ToShortTimeString()));
                }
            }

            return myList;
        }

        


    }
}
