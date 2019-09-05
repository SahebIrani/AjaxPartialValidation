using Microsoft.AspNetCore.Mvc;

using System;

namespace ValidationSample.Controllers
{
    public class PeopleController : Controller
    {
        private readonly MovieContext _context;

        public PeopleController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            string title,
            Genre genre,
            DateTime releaseDate,
            string description,
            decimal price,
            bool preorder)
        {
            var modifiedReleaseDate = releaseDate;
            if (releaseDate == null)
            {
                modifiedReleaseDate = DateTime.Today;
            }

            #region snippet_TryValidateModel
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
                _context.AddMovie(movie);
                _context.SaveChanges();

                return RedirectToAction(actionName: nameof(Index));
            }

            return View(movie);
            #endregion
        }
    }
}
