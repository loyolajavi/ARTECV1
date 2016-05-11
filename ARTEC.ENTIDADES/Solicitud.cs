using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class Solicitud
    {

        public int IdSolicitud { get; set; }
        /// <summary>
        /// Gets or sets the fecha inicio.
        /// </summary>
        /// <value>
        /// The fecha inicio.
        /// </value>
        public DateTime FechaInicio { get; set; }
        /// <summary>
        /// Gets or sets the fecha fin.
        /// </summary>
        /// <value>
        /// The fecha fin.
        /// </value>
        public DateTime FechaFin { get; set; }
        public string Contacto { get; set; }
        public Dependencia unaDependencia { get; set; }
        public Prioridad unaPrioridad { get; set; }
        public UsuarioSistema unResponsable { get; set; }
        public Estado unEstado { get; set; }
        public int MyProperty { get; set; }



    }
}
