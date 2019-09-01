using Microsoft.AspNetCore.Mvc;

using Simple.Models;

using System.Diagnostics;

namespace Simple.Controllers
{
    public class HomeController : Controller
    {
        //private readonly static List<Contact> Contacts = new List<Contact>();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            var model = new Contact { Email = "Sinjul.MSBH@Yahoo.Com", FirstName = "Sinjul", LastName = "MSBH" };

            return PartialView("_ContactModalPartial", model);
        }

        [HttpPost]
        public IActionResult Contact(Contact model)
        {
            //if (ModelState.IsValid)
            //{
            //    Contacts.Add(model);
            //}

            return PartialView("_ContactModalPartial", model);
        }

        [HttpGet]
        public IActionResult PersonForm()
        {
            var model = new Person { Email = "Sinjul.MSBH@Yahoo.Com", FirstName = "Sinjul", LastName = "MSBH" };

            return PartialView("_PersonPartial", model);
        }

        [HttpPost]
        public IActionResult CreatePerson(Person model)
        {
            if (!ModelState.IsValid)
                ModelState.AddModelError("Test", "Message");

            Person person = model;

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

