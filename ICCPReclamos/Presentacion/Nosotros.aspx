<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Nosotros.aspx.cs" Inherits="ICCPReclamos.Presentacion.Nosotros" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../favicon.ico">

    <title>Reclamos ICCP.Net - Presentación Final</title>

 <!-- Bootstrap core CSS -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet">
    
    <!-- Custom styles for this template -->
    <link href="justified-nav.css" rel="stylesheet" />
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
  </head>

  <body>

    <div class="container">

      <!-- The justified navigation menu is meant for single line per list item.
           Multiple lines will require custom code not provided by Bootstrap. -->
      <div class="masthead">
        <h3 class="text-muted">ICCP.Net - Robotech</h3>
        <nav>
          <ul class="nav nav-justified">
            <li><a href="Componentes.aspx">Inicio</a></li>
            <li class="active"><a href="#">Nosotros</a></li>
            <li><a href="#">Accenture</a></li>
          </ul>
        </nav>
      </div>

      <!-- Jumbotron -->
      <div class="jumbotron">
        <h1>Nosotros</h1>
        <p class="lead">Somos un equipo más que un grupo. Jóvenes líderes en sus áreas para desarrollar soluciones vanguardistas y de gran impacto en el mercado</p>
      </div>

      <!-- Example row of columns -->
      <div class="row">
        <div class="col-lg-4">
          <h2>Joel Baez</h2>
          <p>Administrador de servidores y Bases de Datos</p>
          <p><a class="btn btn-primary" href="https://www.facebook.com/profile.php?id=100012334832667" target="_blank" role="button">+ Info &raquo;</a></p>
        </div>
        <div class="col-lg-4">
          <h2>Sebastián Miranda</h2>
          <p>Programador en C# y analista de bases de datos</p>
          <p><a class="btn btn-primary" href="https://www.facebook.com/sebastian.miranda.9828456" target="_blank" role="button">+ Info &raquo;</a></p>
       </div>
        <div class="col-lg-4">
          <h2>Oscar Ortiz</h2>
          <p>Líder de proyecto y programador en C# y ASP.Net.</p>
          <p><a class="btn btn-primary" href="http://facebook.com/oscarinom" target="_blank" role="button">+ Info &raquo;</a></p>
        </div>
      </div>
        <div class="row">
        <div class="col-lg-4">
          <h2>Mariana Rivas</h2>
          <p>Relaciones Pública, analista de sistema y arquitecta de sistemas</p>
          <p><a class="btn btn-primary" href="https://www.facebook.com/marianarivasalvarado" target="_blank" role="button">+ Info &raquo;</a></p>
        </div>
        <div class="col-lg-4">
          <h2>Benjamín Ruiz</h2>
          <p>Análisis de riesgo, arquitectura de sistemas y programador en SQL</p>
          <p><a class="btn btn-primary" href="https://www.facebook.com/benjaamin.ruiz" target="_blank" role="button">+ Info &raquo;</a></p>
       </div>
      </div>

      <!-- Site footer -->
      <footer class="footer">
        <p>&copy; 2017, Robotech Inc.</p>
      </footer>

    </div> <!-- /container -->


    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="../../assets/js/ie10-viewport-bug-workaround.js"></script>
  </body>
</html>
