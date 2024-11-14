using Film.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Film.Controllers
{
    public class FilmController : Controller
    {
        private static IList<Films> films = new List<Films>
        {
            new Films()
            { 
                Id = 1, 
                Name = "Phantom of the Opera", 
                Description = "Based on a 1910 novel by Gaston Leroux, The Phantom of the Opera tells " +
                "the tale of a disfigured musical genius who haunts the Paris Opera House. Mesmerised by " +
                "the talents and beauty of the young soprano Christine, the Phantom lures her as his " +
                "protégé and falls fiercely in love with her.", 
                Price = 0
            },
             
            new Films()
            { 
                Id = 2, 
                Name = "Beauty and the Beast", 
                Description = "A young Prince, imprisoned in the form of a Beast (Dan Stevens), " +
                "can be freed only by true love. What may be his only opportunity arrives when he" +
                " meets Belle (Emma Watson), the only human girl to ever visit the castle since it was enchanted.", 
                Price = 0
            },
            new Films()
            { 
                Id = 3, 
                Name = "Perfume: The Story of a Murder", 
                Description = "Jean-Baptiste Grenouille, born with a superior olfactory sense, " +
                "creates the world's finest perfume. His work, however, takes a dark turn as he " +
                "searches for the ultimate scent. Jean-Baptiste Grenouille, born with " +
                "a superior olfactory sense, creates the world's finest perfume.", 
                Price = 0
            },
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
