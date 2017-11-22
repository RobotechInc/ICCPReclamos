using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ICCPReclamos.Negocio;
using System.Data.SqlClient;
using System.Data;

namespace ICCPReclamos.Datos
{
    public class Datos
    {
        private const string Str =/*
                "Server=45.7.230.103; Database=ICCP_Final; Integrated Security=SSPI;"; */
                "Data Source=45.7.230.103; Initial Catalog=ICCP_Final; User id=sa; Password=16203119s?;";

        public int GetLastReclamo() // la función siguiente devuelve un INTEGER (count) , tiene como objetivo obtener el número mayor de ID en la tabla Reclamos para hacer ingresos adecuados
        {
            var count = 0; // parte count en 0
            using (SqlConnection conn = new SqlConnection(Str)) // se abre conexión
            {
                conn.Open();
                var consulta = "SELECT MAX(id) FROM reclamo"; // usamos la consulta MAX(id)
                var cmd = new SqlCommand(consulta, conn);
                var reader = cmd.ExecuteReader();
                reader.Read(); // leemos
                count = reader.GetInt32(0); // guardamos en count
            }
            return count; // retornamos count
        }

        public List<TipoReclamo> GetTipoReclamo()
        {
            var l = new List<TipoReclamo>(); // generamos la variable Listado para el tipoReclamo
            using (var conn = new SqlConnection(Str))
            {
                // ejecutamos la consulta
                var consulta = "SELECT * from tipoReclamo";
                var cmd = new SqlCommand(consulta, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read()) // guardamos todos los datos en un tipoReclamo (tr)
                {
                    var id = Convert.ToInt32(reader[0]);
                    var nombre = reader[1].ToString();
                    var tr = new TipoReclamo(id, nombre);
                    l.Add(tr); // agregamos cada tipoReclamo (tr) a nuestra lista (l)
                }
            }
            return l; // retornamos la lista
        }

        public void IngresoReclamo(Reclamo rec, string Pdf, DateTime SLA, string Ip) // Ingreso de reclamos, recibe un Reclamo sin retornar algo a cambio, sin embargo puede generar excepción
        // tiene como función ejecutar un procedimiento almacenado para registrar un reclamo
        {
            using (var conn = new SqlConnection(Str))
            {
                /*
                 *    @id INTEGER,
                      @nombre VARCHAR(20),
                      @apellido VARCHAR(20),    
                      @rut VARCHAR(12),
                      @email VARCHAR(100), 
                      @telefono INTEGER, 
                      @area INTEGER, 
                      @comentarios text,
                      @fecha DATETIME,
                      @pdf VARCHAR(100),
                      @sla DATETIME,
                      @ip VARCHAR(100)
                      
                      Se llama a procedimiento almacenado en SQL Server con la estructura anterior, pasando los datos parametrizados
                 */
                var cmd = new SqlCommand("IngresoReclamo", conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id", rec.Id);
                cmd.Parameters.AddWithValue("nombre", rec.Nombre);
                cmd.Parameters.AddWithValue("apellido", rec.Apellido);
                cmd.Parameters.AddWithValue("rut", rec.Rut);
                cmd.Parameters.AddWithValue("email", rec.Email);
                cmd.Parameters.AddWithValue("telefono", rec.Telefono);
                cmd.Parameters.AddWithValue("area", rec.Tipo);
                cmd.Parameters.AddWithValue("comentarios", rec.Comentarios);
                cmd.Parameters.AddWithValue("fecha", rec.Fecha);
                cmd.Parameters.AddWithValue("pdf", Pdf);
                cmd.Parameters.AddWithValue("sla", SLA);
                cmd.Parameters.AddWithValue("ip", Ip);
                try
                { // se envía la query
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar reclamo " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }


        }
        public List<Ingreso> ListadoReclamos() // Función ListadoReclamos, retorna una Lista (l) con todos los reclamos existentes en la base de datos
        {
            var l = new List<Ingreso>(); // generamos la variable Listado
            using (var conn = new SqlConnection(Str))
            {
                // ejecutamos la consulta
                var consulta = "SELECT reclamo.id, usuarios.nombre, usuarios.apellido, usuarios.rut, usuarios.correo, usuarios.telefono, tipoReclamo.id, reclamo.comentarios, reclamo.fecha, reclamo.pdf, slareclamo.fecha_sla  from reclamo INNER JOIN usuarios on reclamo.rut=usuarios.rut INNER JOIN tipoReclamo on reclamo.area=tipoReclamo.id INNER JOIN slareclamo on reclamo.sla_id=slareclamo.id ORDER BY slareclamo.fecha_sla";
                var cmd = new SqlCommand(consulta, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read()) // guardamos todos los datos en un reclamo (r)
                {
                    var ide = Convert.ToInt32(reader[0]);
                    var nom = reader[1].ToString();
                    var ape = reader[2].ToString();
                    var rut = reader[3].ToString();
                    var ema = reader[4].ToString();
                    var tel = Convert.ToInt32(reader[5]);
                    var tip = Convert.ToInt32(reader[6].ToString());
                    var com = reader[7].ToString();
                    var fec = Convert.ToDateTime(reader[8]);
                    var pdf = reader[9].ToString();
                    var sla = Convert.ToDateTime(reader[10]);
                    var r = new Ingreso(ide, nom, ape, rut, ema, tel, tip, com, fec, pdf, sla);
                    l.Add(r); // agregamos cada reclamo r a nuestra lista (l)
                }
            }
            return l; // retornamos la lista
        }

        public Ingreso GetReclamo(int id) // Función GetReclamo, retorna un Reclamo (r) y recibe un Id, con el cuál se ubica el reclamo en la base de datos
        {
            Ingreso r = null; // creamos un reclamo nulo para empezar
            using (var conn = new SqlConnection(Str)) // iniciamos la consulta relacional
            {
                string consulta = "SELECT reclamo.id, usuarios.nombre, usuarios.apellido, usuarios.rut, usuarios.correo, usuarios.telefono, tipoReclamo.id, reclamo.comentarios, reclamo.fecha, reclamo.pdf, reclamo.sla_id  from reclamo INNER JOIN usuarios on reclamo.rut=usuarios.rut INNER JOIN tipoReclamo on reclamo.area=tipoReclamo.id where reclamo.id = " + id;
                var cmd = new SqlCommand(consulta, conn);
                conn.Open();
                var reader = cmd.ExecuteReader(); // ejecutamos los parámetros
                while (reader.Read()) // leemos los datos
                { // y guardamos el reclamo en la variable r
                    var ide = Convert.ToInt32(reader[0]);
                    var nom = reader[1].ToString();
                    var ape = reader[2].ToString();
                    var rut = reader[3].ToString();
                    var ema = reader[4].ToString();
                    var tel = Convert.ToInt32(reader[5]);
                    var tip = Convert.ToInt32(reader[6].ToString());
                    var com = reader[7].ToString();
                    var fec = Convert.ToDateTime(reader[8]);
                    var pdf = reader[9].ToString();
                    var sla = Convert.ToDateTime(reader[10]);
                    r = new Ingreso(ide, nom, ape, rut, ema, tel, tip, com, fec, pdf, sla);
                }
            }
            return r; // retornamos r
        }

        public List<Ingreso> BuscarReclamoRut(string Rut) // Funcion que entrega una Lista de Reclamos, para buscar reclamos vía rut, recibe un Rut (validado previamente en Index)
        {
            var l = new List<Ingreso>();
            using (var conn = new SqlConnection(Str))
            {
                string consulta = "SELECT reclamo.id, usuarios.nombre, usuarios.apellido, usuarios.rut, usuarios.correo, usuarios.telefono, tipoReclamo.id, reclamo.comentarios, reclamo.fecha, reclamo.pdf, reclamo.sla_id  from reclamo INNER JOIN usuarios on reclamo.rut=usuarios.rut INNER JOIN tipoReclamo on reclamo.area=tipoReclamo.id where reclamo.rut =\'" + Rut + "\'";
                var cmd = new SqlCommand(consulta, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var ide = Convert.ToInt32(reader[0]);
                        var nom = reader[1].ToString();
                        var ape = reader[2].ToString();
                        var rut = reader[3].ToString();
                        var ema = reader[4].ToString();
                        var tel = Convert.ToInt32(reader[5]);
                        var tip = Convert.ToInt32(reader[6].ToString());
                        var com = reader[7].ToString();
                        var fec = Convert.ToDateTime(reader[8]);
                        var pdf = reader[9].ToString();
                        var sla = Convert.ToDateTime(reader[10]);
                        var r = new Ingreso(ide, nom, ape, rut, ema, tel, tip, com, fec, pdf, sla);
                        l.Add(r);
                    }
                }
            }
            return l;
        }
        public Ingreso BuscarReclamoId(int id)
        {
            Ingreso r = null;
            using (var conn = new SqlConnection(Str))
            {
                string consulta = "SELECT reclamo.id, usuarios.nombre, usuarios.apellido, usuarios.rut, usuarios.correo, usuarios.telefono, tipoReclamo.id, reclamo.comentarios, reclamo.fecha, reclamo.pdf, reclamo.sla_id  from reclamo INNER JOIN usuarios on reclamo.rut=usuarios.rut INNER JOIN tipoReclamo on reclamo.area=tipoReclamo.id where reclamo.id = " + id;
                var cmd = new SqlCommand(consulta, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var ide = Convert.ToInt32(reader[0]);
                        var nom = reader[1].ToString();
                        var ape = reader[2].ToString();
                        var rut = reader[3].ToString();
                        var ema = reader[4].ToString();
                        var tel = Convert.ToInt32(reader[5]);
                        var tip = Convert.ToInt32(reader[6].ToString());
                        var com = reader[7].ToString();
                        var fec = Convert.ToDateTime(reader[8]);
                        var pdf = reader[9].ToString();
                        var sla = Convert.ToDateTime(reader[10]);
                        r = new Ingreso(ide, nom, ape, rut, ema, tel, tip, com, fec, pdf, sla);
                    }
                }
            }
            return r;
        }
    }
}