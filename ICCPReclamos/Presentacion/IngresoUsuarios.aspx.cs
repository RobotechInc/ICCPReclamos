using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICCPReclamos.Presentacion
{
    public partial class IngresoUsuarios : System.Web.UI.Page
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
        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            var d = new Datos.Datos();

            try
            {
                var user = usuario.Text;
                var contraseña = password.Text;

                var resultado = d.AddUser(user, contraseña);
                if (resultado)
                {

                }
            }
            catch (Exception ex)
            {
                Server.Transfer("Error.aspx?error=" + ex.Message, true);
            }
            Server.Transfer("Exito.aspx", true);

        }
    }
}