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
        public IActionResult SelectAppointment(Appointment a) //***Pass in parameters
        {
            //Validation
            if (ModelState.IsValid)
            {
                //Update database
                context.Appointments.Add(a);
                context.SaveChanges();
            }

            return View("AvailableTours"); //***Needs to be added
        }

        //Select Time page
        [HttpGet]
        public IActionResult AvailableTours()
        {
            return View();
        }

        //Select Time page
        [HttpPost]
        public IActionResult AvailableTours(Appointment a) //***Pass in parameters
        {
            //Validation
            if (ModelState.IsValid)
            {
                //Update database
                context.Appointments.Add(a);
                context.SaveChanges();
            }

            return View("EnterInformation"); //***Needs to be added
        }


        //Form for entering tour info
        [HttpGet]
        public IActionResult EnterInformation()
        {
            return View();
        }

        //Submitting tour information form
        [HttpPost]
        public IActionResult EnterInformation(Group g) //Pass in parameters
        {
            //Validation
            if (ModelState.IsValid)
            {
                //Update database
                context.Groups.Add(g);
                context.SaveChanges();
            }

            return View("ViewAppointments"); //***Change this to appointments list
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
