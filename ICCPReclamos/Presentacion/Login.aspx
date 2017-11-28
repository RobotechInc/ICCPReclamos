<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ICCPReclamos.Presentacion.Login" %>
<!DOCTYPE html>
<html lang="es-CL">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../favicon.ico">

    <title>Ingrese al sistema</title>

    <!-- Bootstrap core CSS -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="signin.css" rel="stylesheet">

    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
  </head>

  <body>

    <div class="container">

      <form class="form-signin" runat="server">
        <h2 class="form-signin-heading">Ingrese al sistema</h2>
        <label for="inputEmail" class="sr-only">Usuario</label>
        <asp:TextBox runat="server" type="text" id="inputRut" class="form-control" placeholder="Usuario" required autofocus></asp:TextBox>
        <label for="inputPassword" class="sr-only">Contraseña</label>
        <asp:TextBox runat="server" type="password" id="inputPassword" class="form-control" placeholder="Password" required></asp:TextBox>
        <div class="checkbox">
        <div runat="server" id="ErrorDiv" class="alert alert-danger" role="alert">Usuario o contraseña incorrectos. Intente nuevamente o comunícate con el administrador</div>
        </div>
            <asp:button type="submit" class="btn btn-default" id="btnEnviar" runat="server" Text="Enviar" onclick="btnEnviar_Click"></asp:button>
      </form>

    </div> <!-- /container -->
  </body>
</html>