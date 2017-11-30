using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ICCPReclamos.Presentacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected int userId()
        {
            var d = new Datos.Datos();
            var username = inputRut.Text;
        var password = inputPassword.Text;

        int userId = d.GetUserIdByUsernameAndPassword(username, password);
            return userId;

    }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UrlReferrer.ToString().Contains("Login.aspx"))
            {
                Response.Redirect("Componentes.aspx");
            }
            ErrorDiv.Visible = false;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {

            if (userId() > 0)
            {
                Session["usuarioValido"] = "valido";
                    Response.Redirect(Request.UrlReferrer.ToString());
                    ErrorDiv.Visible = false;
            }
            else
            {
                inputRut.Text = "";
                inputPassword.Text = "";
                ErrorDiv.Visible = true;
            }


        }
    }
}