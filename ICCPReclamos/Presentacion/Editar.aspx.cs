using ICCPReclamos.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICCPReclamos.Presentacion
{
    public partial class Editar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioValido"] != null)
            {
                if (!Session["usuarioValido"].Equals("valido"))
                {
                    Server.Transfer("Login.aspx", true);
                }
            }
            else
            {
                Server.Transfer("Login.aspx", true);
            }

            int id = int.Parse(Request.QueryString["id"]);

            var v = new Validadores();
            var d = new Datos.Datos();

            var rec = d.GetReclamo(id);

            this.ide.Text = rec.Id.ToString();
            this.ide.Enabled = false;
            this.firstname.Text = rec.Nombre;
            this.lastname.Text = rec.Apellido;
            this.rut.Enabled = false;
            this.rut.Text = rec.Rut;
            this.email.Text = rec.Email;
            if (rec.Tipo == "Atención al cliente")
            {
                this.type.SelectedIndex = 1;
            }
            else if (rec.Tipo == "Comercial")
            {
                this.type.SelectedIndex = 2;
            }
            else
            {
                this.type.SelectedIndex = 3;
            }
            this.tel.Text = rec.Telefono.ToString();
            this.comment.Text = rec.Comentarios;
            this.fec.Text = rec.Fecha.ToString("s");
            this.fec.Enabled = false;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            var info = "Error al entrar";
            var v = new Validadores();
            var d = new Datos.Datos();
            try
            {
                var identi = Convert.ToInt32(ide.Text);
                var nom = firstname.Text;
                var ape = lastname.Text;
                var rut = this.rut.Text;
                var email = this.email.Text;
                var tel = int.Parse(this.tel.Text);
                var type = this.type.Text;
                var com = comment.Text;
                var fec = Convert.ToDateTime(this.fec.Text);
                var rec = new Reclamo(identi, nom, ape, rut, email, tel, type, com, fec);
                d.CerrarReclamo(identi);
            }
            catch (Exception ex)
            {
                Server.Transfer("Error.aspx?error=" + ex.Message, true);
            }
            Server.Transfer("Exito.aspx?", true);

        }
    }
}