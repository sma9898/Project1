using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class Appointment
    {
        //Primary Key 
        [Key]
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public Group Group { get; set; }
        [Required]
        public DateTime AppointmentTime { get; set; }
    }
}
