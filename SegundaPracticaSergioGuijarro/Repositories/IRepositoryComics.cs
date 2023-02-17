using SegundaPracticaSergioGuijarro.Models;

namespace SegundaPracticaSergioGuijarro.Repositories
{
    public interface IRepositoryComics
    {
        public List<Comic> GetComics();



        public void InsertComic(string Nombre, string Imagen, string Descripcion);
    }
}
