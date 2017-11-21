using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICCPReclamos.Negocio
{
    public class TipoReclamo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public TipoReclamo(int Id, string Nombre)
        {
            this.Id = Id;
            this.Nombre = Nombre;
        }
    }
}