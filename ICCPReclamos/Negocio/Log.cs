using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICCPReclamos.Negocio
{
    public class Log
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; }
        public string Ip { get; set; }

        public Log(int Id, string Rut, DateTime Fecha, string Mensaje, string Ip)
        {
            this.Id = Id;
            this.Rut = Rut;
            this.Fecha = Fecha;
            this.Mensaje = Mensaje;
            this.Ip = Ip;
        }

    }
}