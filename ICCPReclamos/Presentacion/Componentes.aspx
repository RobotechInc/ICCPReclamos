<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Componentes.aspx.cs" Inherits="ICCPReclamos.Presentacion.Componentes" %>

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
            <li class="active"><a href="#">Inicio</a></li>
            <li><a href="Nosotros.aspx">Nosotros</a></li>
            <li><a href="#">Accenture</a></li>
          </ul>
        </nav>
      </div>

      <!-- Jumbotron -->
      <div class="jumbotron">
        <h1>Plataforma de Reclamos ICCP.Net !</h1>
        <p class="lead">Hoy es un gran día para tu empresa, mantener los reclamos junto a nuestra plataforma será más fácil que nunca!</p>
        <p><a class="btn btn-lg btn-success" href="index.aspx" target="_blank" role="button">Empieza hoy</a></p>
      </div>

      <!-- Example row of columns -->
      <div class="row">
        <div class="col-lg-4">
          <h2>Ingreso Reclamos</h2>
          <p>Vista para ingresar reclamos en la base de datos. En ella se verificarán todos los datos que entregues. Se necesita autenticación previa para ingresar reclamos.</p>
          <p><a class="btn btn-primary" href="index.aspx" target="_blank" role="button">Acceder &raquo;</a></p>
        </div>
        <div class="col-lg-4">
          <h2>Administración</h2>
          <p>Una vista de administrador especial para tí, con los datos relevantes que sólo tu necesitas como administrador. En ésta vista encontrarás todas las solicitudes, además de un PDF por reclamo para que puedas llevarlo contigo.</p>
          <p><a class="btn btn-primary" href="Listado.cshtml" target="_blank" role="button">Acceder &raquo;</a></p>
       </div>
        <div class="col-lg-4">
          <h2>Mantenedor usuarios</h2>
          <p>Para acceder al sistema, necesitas crear usuarios y así mantener tu plataforma siempre autenticada. Los datos de los usuarios se guardan con encriptación SHA1 para que la información sensible esté de lo más segura.</p>
          <p><a class="btn btn-primary" href="IngresoUsuarios.aspx" target="_blank" role="button">Acceder &raquo;</a></p>
        </div>
      </div>
        <br />
        <br />
        <br />
        <div class="alert alert-success" role="alert">Atención: nuestro sistema actualmente se encuentra en fase Beta. Esto significa que es estable sin embargo su diseño podría no ser el final</div>
        <br />
        <div class="progress">
  <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="85" aria-valuemin="0" aria-valuemax="100" style="width: 85%">
      <p>85% del desarrollo completado</p>
  </div>
</div>
        <div class="row">
        <div class="col-lg-4">
            <img src="../Images/ASP-NET-LOGO-300x300.png" width="200" height="200" class="img-responsive" alt="ASP.Net Logo"/>
          <h2>ASP.Net</h2>
          <p>Plataforma escrita en su totalidad en ASP.Net C#. Te aseguramos una integridad única con un lenguaje de alta competencia en el mercado.</p>
          <p><a class="btn btn-primary" href="https://es.wikipedia.org/wiki/ASP.NET" target="_blank" role="button">+ Info &raquo;</a></p>
        </div>

        <div class="col-lg-4">
          <img src="../Images/microsoft-sql-server.svg" width="200" height="200" class="img-responsive" alt="SQL Server Logo"/>
          <h2>SQL Server</h2>
          <p>Nuestra plataforma utilizar el potente motor de bases de datos de Microsoft. Conocido en el mercado por su estabilidad y su gran capacidad para almacenar grandes volúmenes de datos.</p>
          <p><a class="btn btn-primary" href="https://es.wikipedia.org/wiki/Microsoft_SQL_Server" target="_blank" role="button">+ Info &raquo;</a></p>
       </div>

        <div class="col-lg-4">
           <img src="../Images/noun_993097_cc.png" width="180" height="180" class="img-responsive" alt="Well Documented Logo"/>
          <h2>Bien documentado</h2>
          <p>Deseas agregar más cosas a tu plataforma ? Deseas agregar más datos a las solicitudes de tus clientes ? No hay problema, la documentación incluída te ayudará a mantener tu plataforma a gusto.</p>
          <p><a class="btn btn-primary" href="mailto:robotechinc251@gmail.com" target="_blank" role="button">Obtén tu copia &raquo;</a></p>
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
