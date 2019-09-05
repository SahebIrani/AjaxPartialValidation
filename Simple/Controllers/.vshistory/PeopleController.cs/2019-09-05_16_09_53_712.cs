using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

using Simple.Models;

using System;

namespace Simple.Controllers
{
    public class PeopleController : Controller
    {
        [HttpGet] public IActionResult Create() { return View(); }

        //[AcceptVerbs(nameof(HttpMethod.Get), nameof(HttpMethod.Post))]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Person model)
        {
            if (Request.Method.Equals(nameof(HttpMethod.Get),
                                   StringComparison.OrdinalIgnoreCase))
                return View();

            DateTime modifiedBirthDate = model.BirthDate;
            if (modifiedBirthDate == null)
                modifiedBirthDate = DateTime.Today;

            Person person = new Person
            {
                BirthDate = modifiedBirthDate,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            PersonIValidatable personIValidatable = new PersonIValidatable
            {
                BirthDate = modifiedBirthDate,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            TryValidateModel(person);

            if (ModelState.IsValid)
                return RedirectToAction(actionName: nameof(Index));

            bool validPersonIValidatable = TryValidateModel(personIValidatable);

            if (ModelState.IsValid)
                return RedirectToAction(actionName: nameof(Index));

            return View(person);
        }
    }
}
