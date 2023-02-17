using SegundaPracticaSergioGuijarro.Models;
using System.Data;
using System.Data.SqlClient;

#region

//CREATE OR ALTER PROCEDURE SP_INSERT_COMIC
//(@IDCOMIC int,
//@NOMBRE NVARCHAR(150),
//@IMAGEN NVARCHAR(600),
//@DESCRIPCION NVARCHAR(500)
//)
//AS
//INSERT INTO COMICS VALUES(@IDCOMIC, @NOMBRE, @IMAGEN, @DESCRIPCION)
//GO


#endregion



namespace SegundaPracticaSergioGuijarro.Repositories
{
    public class RepositoryComicsSQL : IRepositoryComics
    {

        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;
        private DataTable tablaComics;

        public RepositoryComicsSQL()
        {
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;User ID=sa; Password=MCSD2022";
            string sql = "SELECT * FROM COMICS";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connectionString);
            this.tablaComics = new DataTable();
            adapter.Fill(this.tablaComics);

            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<Comic> GetComics()
        {
            List<Comic> comics = new List<Comic>();
            var consulta = from datos in this.tablaComics.AsEnumerable()
                           select new Comic
                           {
                               Idcomic = datos.Field<int>("IDCOMIC"),
                               Nombre = datos.Field<string>("NOMBRE"),
                               Imagen = datos.Field<string>("IMAGEN"),
                               Descripcion = datos.Field<string>("DESCRIPCION"),
            
                           };

            return consulta.ToList();
        }


        public int FindLastId()
        {
          

            var consulta = from datos in this.tablaComics.AsEnumerable()   
                           select datos;

            int maximo = consulta.Max(z => z.Field<int>("IDCOMIC"));

            return maximo;

        }



    }
}
