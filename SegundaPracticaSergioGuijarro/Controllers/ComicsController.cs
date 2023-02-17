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
            int ultimoID = this.repo.FindLastId();
            ViewData["NUEVOID"] = ultimoID+1;
            return View();
        }

        [HttpPost]
        public IActionResult Insert(int Idcomic, string Nombre, string Descripcion, string Imagen)
        {   
          
            return View("Index");
        }


    }
}
