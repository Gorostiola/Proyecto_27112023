using DataUsuarios;
using EntityUsuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussUsuarios
{
    public class BUsuarios
    {

        DUsuarios data = new DUsuarios();

        public List<EUsuarios> Obtener()
        {
            DataTable dt = data.Obtener();
            List<EUsuarios> list = new List<EUsuarios>();

            foreach(DataRow dr in dt.Rows)
            {
                EUsuarios usuari = new EUsuarios();

                usuari.id = Convert.ToInt32(dr["Id"]);
                usuari.nombre = Convert.ToString(dr["Nombre"]);
                usuari.apellidop = Convert.ToString(dr["ApellidoP"]);
                usuari.apellidom = Convert.ToString(dr["ApellidoM"]);
                usuari.edad = Convert.ToInt32(dr["Edad"]);
                usuari.fecha = Convert.ToDateTime(dr["FechaNaci"]).ToString("dd-MM-yyyy");

                list.Add(usuari);
            }
            return list;
        }

        public void Agregar(EUsuarios usua)
        {
            int resultado = data.Agregar(usua.nombre, usua.apellidop, usua.apellidom, usua.fecha);

            if (resultado != 1) //En if, se puede poner sin llaves, solo cuando va a tener 1 sola linea, por logica de C#
                throw new ApplicationException($"Error al agregar {usua.NombreCompleto}");
        }


        public void Eliminar(EUsuarios usua)
        {
            int fa = data.Eliminar(usua.id);
            if (fa != 1)
            {
                throw new ApplicationException($"Error al eliminar el usuario: {usua.nombre}");
            }

        }

        ////////////////
        public EUsuarios ObtenerId(int id)
        {
            DataRow dr = data.ObtenerId(id);

            EUsuarios usu = new EUsuarios();

            usu.id = Convert.ToInt32(dr["Id"]);
            usu.nombre = Convert.ToString(dr["Nombre"]);
            usu.apellidop = Convert.ToString(dr["ApellidoP"]);
            usu.apellidom = Convert.ToString(dr["ApellidoM"]);
            usu.edad = Convert.ToInt32(dr["Edad"]);
            usu.fecha = Convert.ToDateTime(dr["FechaNaci"]).ToString("dd-MM-yyyy");

            return usu;
        }

        public void Editar(EUsuarios per)
        {
            int fa = data.Editar(per.nombre, per.apellidop, per.apellidom, per.fecha, per.id);
            if (fa != 1)
            {
                throw new ApplicationException($"Error al editar a la persona: {per.nombre}");
            }

        }

        public List<EUsuarios> Buscar(string valor)
        {
            DataTable dt = data.Buscar(valor);
            List<EUsuarios> list = new List<EUsuarios>();
            foreach (DataRow dr in dt.Rows)
            {
                EUsuarios usu = new EUsuarios();

                usu.id = Convert.ToInt32(dr["Id"]);
                usu.nombre = Convert.ToString(dr["Nombre"]);
                usu.apellidop = Convert.ToString(dr["ApellidoP"]);
                usu.apellidom = Convert.ToString(dr["ApellidoM"]);
                usu.edad = Convert.ToInt32(dr["Edad"]);
                usu.fecha = Convert.ToDateTime(dr["FechaNaci"]).ToString("dd-MM-yyyy");

                list.Add(usu);

            }
            return list;
        }


    }
}
