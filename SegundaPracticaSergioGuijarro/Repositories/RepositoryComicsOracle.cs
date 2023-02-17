
using SegundaPracticaSergioGuijarro.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

#region
//CREATE OR REPLACE PROCEDURE SP_INSERT_COMIC
//(P_IDCOMIC COMICS.IDCOMIC%TYPE,
//P_NOMBRE COMICS.NOMBRE%TYPE,
//P_IMAGEN COMICS.IMAGEN%TYPE,
//P_DESCRIPCION COMICS.DESCRIPCION%TYPE
//)
//AS
//BEGIN
//INSERT INTO COMICS VALUES(P_IDCOMIC, P_NOMBRE, P_IMAGEN, P_DESCRIPCION);
//COMMIT;
//END;

#endregion


namespace SegundaPracticaSergioGuijarro.Repositories
{
    public class RepositoryComicsOracle : IRepositoryComics
    {

        private OracleConnection cn;
        private OracleCommand com;
        private OracleDataAdapter adapter;
        private OracleDataReader reader;
        private DataTable tablaComics;

        public RepositoryComicsOracle()
        {
            string connectionString = @"Data Source=LOCALHOST:1521/XE; Persist Security Info=True;User Id=SYSTEM;Password=oracle";
            string sql = "SELECT * FROM COMICS";
            OracleDataAdapter adapter = new OracleDataAdapter(sql, connectionString);
            this.tablaComics = new DataTable();
            adapter.Fill(this.tablaComics);

            this.cn = new OracleConnection(connectionString);
            this.com = new OracleCommand();
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


        public void InsertComic(int Idcomic, string Nombre, string Imagen, string Descripcion)
        {
            OracleParameter pamid = new OracleParameter(":P_IDCOMIC", Idcomic);
            this.com.Parameters.Add(pamid);
            OracleParameter pamnombre = new OracleParameter(":P_NOMBRE", Nombre);
            this.com.Parameters.Add(pamnombre);
            OracleParameter pamimagen = new OracleParameter(":P_IMAGEN", Imagen);
            this.com.Parameters.Add(pamimagen);
            OracleParameter pamdescripcion = new OracleParameter(":P_DESCRIPCION", Descripcion);
            this.com.Parameters.Add(pamdescripcion);




            this.com.CommandType = System.Data.CommandType.StoredProcedure;
            this.com.CommandText = "SP_INSERT_COMIC";

            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.com.Parameters.Clear();
            this.cn.Close();


        }







    }
}
