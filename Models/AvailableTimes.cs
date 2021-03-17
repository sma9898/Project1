using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class AvailableTimes
    {
        public DateTime Date { get; set; }

        //List of all possible times for a given day
        public List<string> TimesList = new List<string>(new string []{ "8:00 AM", "9:00 AM", "10:00 AM", "11:00 AM", "12:00 PM", "1:00 PM", "2:00 PM", "3:00 PM", "4:00 PM", "5:00 PM", "6:00 PM", "7:00 PM", "8:00 PM" });

    }
}
