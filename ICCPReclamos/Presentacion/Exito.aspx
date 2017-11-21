<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="ICCPReclamos.Presentacion.Exito" %>

<!DOCTYPE html>
<html lang ="es-cl">
<head runat="server">
    <title>Reclamos</title>
    <meta charset="utf-8"> 
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://afeld.github.io/emoji-css/emoji.css" rel="stylesheet">
    <link href="custom.css" rel="stylesheet">
</head>
<body>


<div class="container">



    <nav class="navbar navbar-inverse">
  <div class="container-fluid">
    <div class="navbar-header">
      <a class="navbar-brand" href="index.aspx">Robotech ICCP.Net</a>
    </div>
    <ul class="nav navbar-nav">
      <li class="active"><a href="index.aspx">Inicio</a></li>
      <li><a href="Listado.cshtml">Listado Reclamos</a></li>
      <li><a href="#">NOTENABLED</a></li>
    </ul>
    <ul class="nav navbar-nav navbar-right">
      <li><a href="#"><span class="glyphicon glyphicon-user"></span> Registro</a></li>
      <li><a href="#"><span class="glyphicon glyphicon-log-in"></span> Login</a></li>
    </ul>
  </div>
</nav>

      <div class="jumbotron">
        <h2>Listo <i class="em em-v"></i> !</h2>
        <p class="lead">Hemos agregado tu solicitud y ésta será revisada a la brevedad por nuestros ejecutivos.</p>
        <p><a href="Listado.cshtml">Ir al listado</a></p>
      </div>

    <footer class="blog-footer">
      <p>ICCP.Net Platform made with ♥ by <a href="index.aspx">Robotech INC</a></p>
      <p>
        <a href="#">Hacia arriba !</a>
      </p>
        </footer>
</body>

<!-- bootstrap 3 minimizado -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">

<!-- jQuery -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

<!-- último js de bs 3 -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</html>