using SegundaPracticaSergioGuijarro.Models;

namespace SegundaPracticaSergioGuijarro.Repositories
{
    public interface IRepositoryComics
    {
        public List<Comic> GetComics();

        public int FindLastId();

        public void InsertComic(int Idcomic, string Nombre, string Imagen, string Descripcion);
    }
}
