using Microsoft.AspNetCore.Mvc;
using SegundaPracticaSergioGuijarro.Models;
using SegundaPracticaSergioGuijarro.Repositories;
namespace SegundaPracticaSergioGuijarro.Controllers
{
    public class ComicsController : Controller
    {

        private  IRepositoryComics repo;
        public ComicsController(IRepositoryComics repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Comic> comics = this.repo.GetComics();
            return View(comics);
        }
        public IActionResult Insert()
        {
         
            return View();
        }

        [HttpPost]
        public IActionResult Insert(string Nombre, string Descripcion, string Imagen)
        {
            this.repo.InsertComic(Nombre, Descripcion, Imagen);

         
            return RedirectToAction("Index");
        }


    }
}
