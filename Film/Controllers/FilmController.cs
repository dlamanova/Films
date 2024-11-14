using Film.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Film.Controllers
{
    public class FilmController : Controller
    {
        private static IList<Films> films = new List<Films>
        {
            new Films(){ Id = 1, Name = "Film1", Description = "Descr1", Price = 0},
            new Films(){ Id = 2, Name = "Film2", Description = "Descr2", Price = 0},
            new Films(){ Id = 3, Name = "Film3", Description = "Descr3", Price = 0},
        };
        // GET: FilmController
        public ActionResult Index()
        {
            return View(films);
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            return View(films.FirstOrDefault(x => x.Id == id));
        }

        // GET: FilmController/Create
        public ActionResult Create()
        {
            return View(new Films());
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Films film)
        {
            film.Id = films.Count + 1;
            films.Add(film);
            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            var filmToEdit = films.FirstOrDefault(x => x.Id == id);
            return View(filmToEdit);
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Films newFilm)
        {
            var filmToEdit = films.FirstOrDefault(x => x.Id == id);
            filmToEdit.Name = newFilm.Name;
            filmToEdit.Description = newFilm.Description;
            filmToEdit.Price = newFilm.Price;
            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            var filmToDel = films.FirstOrDefault(x => x.Id == id);
            return View(filmToDel);
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var filmToDel = films.FirstOrDefault(x => x.Id == id);
            films.Remove(filmToDel);
            return RedirectToAction(nameof(Index));
        }
    }
}
