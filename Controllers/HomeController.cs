using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project1.Models;
using Project1.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        //Temple appointment information
        private TempleAppointmentContext context { get; set; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, TempleAppointmentContext con)
        {
            _logger = logger;
            context = con;
        }

        //Home page
        public IActionResult Index()
        {
            return View();
        }

        //Select Date page
        [HttpGet]
        public IActionResult SelectAppointment()
        {
            return View();
        }

        //Select Date page

        [HttpPost]
        public IActionResult SelectAppointment(DateTime Times)
        {
            return View(new AvailableToursViewModel(Times, context)
            { });

        }

        [HttpPost]
        public IActionResult SelectTime(DateTime date, string time)
        {
            //Make the passed parameters a datetime object
            string AppointmentDate = date.Date.ToString();
            AppointmentDate = AppointmentDate.Replace(" 12:00:00 AM", "");
            string myAppointment = AppointmentDate + " " + time;
            DateTime AppointmentInfo = Convert.ToDateTime(myAppointment);

            //Create new view model with the time
            return View("EnterInformation", new GroupAppointmentViewModel
            {
                AppointmentTime = AppointmentInfo
            });

        }



        //Form for entering tour info
        [HttpGet]
        public IActionResult EnterInformation()
        {
            return View();
        }

        //Submitting tour information form
        [HttpPost]
        public IActionResult EnterInformation(GroupAppointmentViewModel model) //Pass in parameters
        {
            //Validation
            if (ModelState.IsValid)
            {
                //Update database
                context.Groups.Add(model.Group);
                context.Appointments.Add(new Appointment { Group = model.Group, AppointmentTime = model.AppointmentTime });
                context.SaveChanges();
                return RedirectToAction("ViewAppointments");

            }
            else
            {
                return View(model);
            }
        }

        //View Appointments Page
        [HttpGet]
        public IActionResult ViewAppointments()
        {
            return View(context);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
