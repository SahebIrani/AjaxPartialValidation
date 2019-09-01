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
        [HttpPost] public IActionResult PersonForm(Person person) => PartialView("_PersonPartial", person);

        [HttpPost]
        public IActionResult CreatePerson(Person model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Test", "List Error Message");
                return PartialView("_PersonPartial", model);
            }

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

