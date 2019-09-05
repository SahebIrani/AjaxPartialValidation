using Microsoft.AspNetCore.Mvc;

using Simple.Models;

using System;

namespace Simple.Controllers
{
    public class PeopleController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person model)
        {
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

            var tb = TryValidateModel(movie);

            if (ModelState.IsValid)
            {
                return RedirectToAction(actionName: nameof(Index));
            }

            return View(movie);
        }
    }
}
