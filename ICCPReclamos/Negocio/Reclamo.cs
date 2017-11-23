using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICCPReclamos.Negocio
{
    public class Reclamo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rut { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public string Tipo { get; set; }
        public string Comentarios { get; set; }
        public DateTime Fecha { get; set; }

        public Reclamo(int Id, string Nombre, string Apellido, string Rut, string Email, int Telefono, string Tipo, string Comentarios, DateTime Fecha)
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
        }

        public Reclamo()
        {
            this.Id = 0;
            this.Nombre = "";
            this.Apellido = "";
            this.Rut = "";
            this.Email = "";
            this.Telefono = 0;
            this.Tipo = "";
            this.Comentarios = "";
            this.Fecha = DateTime.Now;
        }

    }
}