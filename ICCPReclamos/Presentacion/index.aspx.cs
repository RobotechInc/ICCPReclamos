using ICCPReclamos.Negocio;
using ICCPReclamos.Datos;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICCPReclamos.Presentacion
{
    public partial class index : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                var d = new Datos.Datos();
                List<TipoReclamo> tipoReclamos = d.GetTipoReclamo();
                type.DataTextField = "nombre";
                type.DataValueField = "id";
                type.DataSource = tipoReclamos;
                type.DataBind();
                type.Items.Insert(0, new System.Web.UI.WebControls.ListItem("<Ingrese Tipo de Reclamo>", "0"));

            }
        }
        public string GetIP()
        {
            var IPCliente = "";
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPCliente = Convert.ToString(IP);
                }
            }
            return IPCliente;

        }

        public string GeneratePdf(Reclamo rec)
        {

            var doc = new Document(PageSize.A4, 10f, 10f, 120f, 100f);
            var strFilePath = Server.MapPath("~/PdfUploads/");

            var fileName = "Reclamo_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".pdf";

            var titleFont = FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.UNDERLINE, BaseColor.BLACK);
            var h1Font = FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.NORMAL);
            var bodyFont = FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.NORMAL, BaseColor.DARK_GRAY);

            try
            {
                var pdfWriter = PdfWriter.GetInstance(doc, new FileStream(strFilePath + fileName, FileMode.Create));
                pdfWriter.PageEvent = new ITextEvents();
                doc.Open();

                var tblContainer = new PdfPTable(6) { TotalWidth = 520f, LockedWidth = true };
                float[] widths = { 20f, 120f, 100f, 100f, 80f, 100f };
                tblContainer.SetWidths(widths);
                var heading = new Phrase("Detalles del reclamo: " + rec.Id, h1Font);
                var titleId = new Phrase("ID", titleFont);
                var titleNombre = new Phrase("Nombre", titleFont);
                var titleRut = new Phrase("RUT", titleFont);
                var titleEmail = new Phrase("Email", titleFont);
                var titleTelefono = new Phrase("Teléfono", titleFont);
                var titleFecha = new Phrase("Fecha", titleFont);

                var cellTicketName = new PdfPCell(heading) { Colspan = 6, Border = 0 };

                var cellTitleId = new PdfPCell(titleId);
                var cellTitleNombre = new PdfPCell(titleNombre);
                var cellTitleRut = new PdfPCell(titleRut);
                var cellTitleEmail = new PdfPCell(titleEmail);
                var cellTitleTelefono = new PdfPCell(titleTelefono);
                var cellTitleFecha = new PdfPCell(titleFecha);

                cellTitleId.Border = 0;
                cellTitleNombre.Border = 0;
                cellTitleRut.Border = 0;
                cellTitleEmail.Border = 0;
                cellTitleTelefono.Border = 0;
                cellTitleFecha.Border = 0;

                tblContainer.AddCell(cellTicketName);

                tblContainer.AddCell(cellTitleId);
                tblContainer.AddCell(cellTitleNombre);
                tblContainer.AddCell(cellTitleRut);
                tblContainer.AddCell(cellTitleEmail);
                tblContainer.AddCell(cellTitleTelefono);
                tblContainer.AddCell(cellTitleFecha);

                doc.Add(tblContainer);
                var nombreApellido = rec.Nombre + " " + rec.Apellido;
                var tblResult = new PdfPTable(6) { TotalWidth = 520f, LockedWidth = true };
                tblResult.SetWidths(widths);
                var registroId = new Phrase(rec.Id.ToString(), bodyFont);
                var registroNombre = new Phrase(nombreApellido, bodyFont);
                var registroRut = new Phrase(rec.Rut, bodyFont);
                var registroEmail = new Phrase(rec.Email, bodyFont);
                var registroTelefono = new Phrase(rec.Telefono.ToString(), bodyFont);
                var registroFecha = new Phrase(rec.Fecha.ToString(), bodyFont);
                var cellId = new PdfPCell(registroId);
                var cellNombre = new PdfPCell(registroNombre);
                var cellRut = new PdfPCell(registroRut);
                var cellEmail = new PdfPCell(registroEmail);
                var cellTelefono = new PdfPCell(registroTelefono);
                var cellFecha = new PdfPCell(registroFecha);

                cellId.Border = 0;
                cellNombre.Border = 0;
                cellRut.Border = 0;
                cellEmail.Border = 0;
                cellTelefono.Border = 0;
                cellFecha.Border = 0;
                tblResult.AddCell(cellId);
                tblResult.AddCell(cellNombre);
                tblResult.AddCell(cellRut);
                tblResult.AddCell(cellEmail);
                tblResult.AddCell(cellTelefono);
                tblResult.AddCell(cellFecha);

                doc.Add(tblResult);

                var tblComentarios = new PdfPTable(1) { TotalWidth = 520f, LockedWidth = true };
                var registroComentarios = new Phrase(rec.Comentarios, bodyFont);
                var cellComentarios = new PdfPCell(registroComentarios);
                cellComentarios.Border = 0;
                tblComentarios.AddCell(cellComentarios);
                doc.Add(tblComentarios);

                doc.Close();
                byte[] contents = File.ReadAllBytes(strFilePath + fileName);
                return fileName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                doc.Close();
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            var v = new Validadores();
            var d = new Datos.Datos();
            Reclamo rec = new Reclamo();

            try
            {
                var nom = firstname.Text;
                var ape = lastname.Text;
                var rut = this.rut.Text;
                if (v.validarRut(rut) == false)
                {
                    throw new Exception("Rut inválido");
                }
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                var email = this.email.Text;
                var tel = int.Parse(this.tel.Text);
                var type = this.type.SelectedIndex.ToString();
                var com = comment.Text;
                var fec = DateTime.Now;

                rec = new Reclamo(d.GetLastReclamo() + 1, nom, ape, rut, email, tel, type, com, fec);
                var IP = GetIP();
                var pdf = GeneratePdf(rec);
                var SLA = fec.AddHours(int.Parse(this.slaHoras.Text));
                d.IngresoReclamo(rec,pdf,SLA,IP);
            }
            catch (Exception ex)
            {
                Server.Transfer("Error.aspx?error=" + ex.Message, true);
            }
            Server.Transfer("Exito.aspx", true);

        }
    }
}