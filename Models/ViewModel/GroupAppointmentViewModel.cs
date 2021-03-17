using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models.ViewModel
{
    public class GroupAppointmentViewModel
    {
        //Time for the appointment and group info
        public DateTime AppointmentTime { get; set; }
        public Group Group { get; set; }

    }
}
