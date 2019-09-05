using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

using Simple.Models;

using System;

namespace Simple.Controllers
{
    public class PeopleController : Controller
    {
        [AcceptVerbs(nameof(HttpMethod.Get), nameof(HttpMethod.Post))]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person model)
        {
            HttpMethod.Post
            Request.HttpContext.Request.

            var modifiedBirthDate = model.BirthDate;
            if (modifiedBirthDate == null)
                modifiedBirthDate = DateTime.Today;

            var person = new Person
            {
                BirthDate = modifiedBirthDate,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var validPerson = TryValidateModel(person);

            if (ModelState.IsValid)
                return RedirectToAction(actionName: nameof(Index));

            return View(person);
        }
    }
}
