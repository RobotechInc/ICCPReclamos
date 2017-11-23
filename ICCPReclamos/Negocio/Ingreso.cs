using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICCPReclamos.Negocio
{
    public class Ingreso
    {
        public int Id { get; set; } // tabla reclamo
        public string Nombre { get; set; } // tabla usuario
        public string Apellido { get; set; }
        public string Rut { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public string Tipo { get; set; } // tipo reclamo
        public string Comentarios { get; set; } // reclamo
        public DateTime Fecha { get; set; } // reclamo
        public string Pdf { get; set; } // pdf reclamo
        public DateTime SLA { get; set; } // fecha SLA

        public Ingreso(int Id, string Nombre, string Apellido, string Rut, string Email, int Telefono, string Tipo, string Comentarios, DateTime Fecha, string Pdf, DateTime SLA)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Rut = Rut;
            this.Email = Email;
            this.Telefono = Telefono;
            this.Tipo = Tipo;
            this.Comentarios = Comentarios;
            this.Fecha = Fecha;
            this.Pdf = Pdf;
            this.SLA = SLA;
        }

    }
}