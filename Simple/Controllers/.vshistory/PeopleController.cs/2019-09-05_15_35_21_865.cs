using Microsoft.AspNetCore.Mvc;

using Simple.Models;

using System;

namespace Simple.Controllers
{
    public class PeopleController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            var modifiedBirthDate = person.BirthDate;
            if (modifiedBirthDate == null)
                modifiedBirthDate = DateTime.Today;

            var movie = new Movie
            {
                Title = title,
                Genre = genre,
                ReleaseDate = modifiedReleaseDate,
                Description = description,
                Price = price,
                Preorder = preorder,
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
