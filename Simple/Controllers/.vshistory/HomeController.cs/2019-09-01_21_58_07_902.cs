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
            var model = new Contact { };

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

