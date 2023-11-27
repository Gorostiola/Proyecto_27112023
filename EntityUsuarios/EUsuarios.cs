using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityUsuarios
{
    public class EUsuarios
    {
        public int id { get; set; }

        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [DisplayName("Apellido Paterno")]
        public string apellidop { get; set; }

        [DisplayName("Apellido Materno")]
        public string apellidom { get; set; }

        [DisplayName("Fecha")]
        public string fecha { get; set; }

        [DisplayName("Edad")]
        public int edad { get; set; }


        private string NomCom;

        public string NombreCompleto
        {
            get 
            {
                NomCom = $"{nombre} {apellidop} {apellidom}";
                return NomCom; 
            }
        }



    }
}
