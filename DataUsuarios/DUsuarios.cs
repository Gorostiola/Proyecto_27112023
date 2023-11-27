using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataUsuarios                  //RECUERDA QUE LO UNICO QUE VA A CAMBIAR ES LA DATA POR EL SP
{
    public class DUsuarios
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable Obtener()
        {//Siempre que se hace un SP se hace 1ro con el SqlCommand por que ya no ejecutaremos un query si no un SP
         //Un Sp siempre se ejecutara con un comando
         //Se manda el nombre del Store Procedure y despues el nombre de la conexion
            SqlCommand com = new SqlCommand("SpObtenerUsuarios", con);
            com.CommandType = CommandType.StoredProcedure;//Para seleccionar el tipo

            SqlDataAdapter da = new SqlDataAdapter(com);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        ////////////
        public DataRow ObtenerId(int id)
        {//Siempre que se hace un SP se hace 1ro con el SqlCommand por que ya no ejecutaremos un query si no un SP
         //Un Sp siempre se ejecutara con un comando
         //Se manda el nombre del Store Procedure y despues el nombre de la conexion
            SqlCommand com = new SqlCommand("SpObtenerIdUsuarios", con);
            com.CommandType = CommandType.StoredProcedure;//Para seleccionar el tipo

            com.Parameters.AddWithValue("@Id", id);

            SqlDataAdapter da = new SqlDataAdapter(com);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt.Rows[0];
        }






        //int para informarle al bussines que se ejecuto correctamente
        public int Agregar(string Nombre, string ApellidoP, string ApellidoM, string Fecha)
        {
            SqlCommand com = new SqlCommand("SpAgregarUsuarios", con);//Conexion
            com.CommandType = CommandType.StoredProcedure; //Tipo StoreProcedure 

            //Se tienen que mandar los parametros que requiere
            com.Parameters.AddWithValue("@Nom", Nombre); //El primero es como se llama la variable de SP, despues que valor va a tener
            com.Parameters.AddWithValue("@App", ApellidoP);
            com.Parameters.AddWithValue("@Apm", ApellidoM);
            com.Parameters.AddWithValue("@Fecha", Fecha);

            try
            {
                con.Open();
                int fa = com.ExecuteNonQuery();
                con.Close();

                return fa;

            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }

        ///////////////////////////
        public int Eliminar(int id)
        {
            //string query = $"delete Bandas where Id={id}";
            //SqlCommand com = new SqlCommand(query, con);
            SqlCommand com = new SqlCommand("SpEliminarUsuarios", con);
            com.CommandType = CommandType.StoredProcedure; //Tipo StoreProcedure 

            //Se tienen que mandar los parametros que requiere
            com.Parameters.AddWithValue("@Id", id);

            try
            {
                con.Open();
                int filaAfectada = com.ExecuteNonQuery();
                con.Close();
                return filaAfectada;
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }

        public int Editar(string nombre, string apellidop, string apellidom, string fecha, int id)
        {
            SqlCommand com = new SqlCommand("SpEditarUsuarios", con);
            com.CommandType = CommandType.StoredProcedure;
            //Se les asigna un valor 
            com.Parameters.AddWithValue("@Id", id);
            com.Parameters.AddWithValue("@Nom", nombre);
            com.Parameters.AddWithValue("@App", apellidop);
            com.Parameters.AddWithValue("@Apm", apellidom);
            com.Parameters.AddWithValue("@Fecha", fecha);

            try
            {
                con.Open();
                int fa = com.ExecuteNonQuery();
                con.Close();
                return fa;
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }

        public DataTable Buscar(string valor)
        {
            SqlCommand com = new SqlCommand("SpBuscarUsuarios", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Valor", valor);

            SqlDataAdapter da = new SqlDataAdapter(com);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }



    }
}
