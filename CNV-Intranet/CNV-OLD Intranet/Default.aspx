<%@ Page Language="C#" AutoEventWireup="true" Inherits="_Default" Codebehind="Default.aspx.cs" %>
<!DOCTYPE html>
<html lang="es">
<head>
	<meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=Edge">
	<meta name="author" content="CNV">
	<meta name="viewport" content="width=device-width, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no">
	<title>CNV</title>
	<link rel="icon" href="favicon.png">

	<meta name="description" content="" />
	
	<!--Social-->
	<meta name="twitter:card" value="summary">
	<meta property="og:title" content="CNV" />
	<meta property="og:type" content="website" />
	<meta property="og:url" content="" />
	<meta property="og:image" content="" />
	<meta property="og:description" content="" />

	<link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,700" rel="stylesheet">

	<link rel="stylesheet" type="text/css" href="assets/css/reset.css" />
    <link rel="stylesheet" type="text/css" href="assets/css/easy-autocomplete.min.css" />
	<link rel="stylesheet" type="text/css" href="assets/css/style.css" />    
	
	<!--[if IE]>
	<link rel="stylesheet" type="text/css" href="styles/styles-ie.css" />
	<![endif]-->	

	<script src="assets/js/jquery.min.js"></script>    
	<script src="assets/js/scripts.js"></script>
    <script src="assets/js/jquery.easy-autocomplete.min.js"></script>
</head>
<body>
	<header>
		<div class="container">
			<div class="logo">
				<a href="<%= Page.ResolveUrl("http://www.cnv.gob.ar") %>"><img src="assets/images/logo_cnv.png" alt="CNV" /></a>
			</div>
			<%--<h1>BIENVENIDO <%=usuario.Nombre.ToUpper() + " " + usuario.Apellido.ToUpper() %></h1>--%>
<%--            <h1>BIENVENIDO <%=usuario.NombreMostrable.ToUpper() %></h1>--%>
			<p><strong>Estamos desarrollando la nueva intranet de CNV.</strong></p>
			<p>En breve, podrás disfrutar de todos los contenidos.</p>
			<div class="searchform" >
				<form type="post" id="frmSearch" action="<%= Page.ResolveUrl("~/") %>">
					<label>Utilizá el nuevo buscador de internos</label>
					<div class="fieldcontainer">
						<input type="search" runat="server" id="search" name="search" placeholder="Ingresá nombre, apellido o departamento"/>
						<button type="submit"/>
					</div>
				</form>
			</div>
		</div>
	</header>

    <section class="results" id="results" runat="server" visible="false">
		<%--<div class="container bottomline">--%>
        <div class="container">
			<h1>Resultados de la búsqueda:</h1> 
					
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="resultimage">
                        <img class="resultframe" src="assets/images/marco_foto.png" alt="Resultado"/>
                        <div class="resultcircle-positioner">
                            <div class="resultcircle" style="background: url('<%= PathImagePerfil %><%# Eval("CUIL").ToString().Trim() %>.jpg') no-repeat center center; background-size:cover">
                                <div class="shadow"></div>
                            </div>
                        </div>
                    </div>

<%--			        <article class="resultdata">
				        <h2><strong><%# Eval("Apellido").ToString().Trim() %>,</strong> <%# Eval("Nombres").ToString().Trim() %></h2>
				        <p><label>Mail:</label><a href='mailto:<%# Eval("Email").ToString().Trim() %>'><%# Eval("Email").ToString().Trim() %></a></p>
				        <p><label>Sector y Cargo:</label><span><%# Eval("Sector").ToString().Trim() %>, <%# Eval("Puesto").ToString().Trim() %></span></p>
                        <p><label>Edificio y Piso:</label><span><%# Eval("Edificio").ToString().Trim() %>, <%# Eval("Piso").ToString().Trim() %></span></p>
				        <p><label>Interno:</label><span><%# Eval("Telefono").ToString().Trim() %></span></p>
			        </article>--%>
         
			        <article class="resultdata">
				        <h2><strong><%# Eval("Apellido").ToString().Trim() %>,</strong> <%# Eval("Nombres").ToString().Trim() %></h2>
				        <p><span><%# Eval("Sector").ToString().Trim() %></p>
				        <p><a href='mailto:<%# Eval("Email").ToString().Trim() %>'><%# Eval("Email").ToString().Trim() %></a></p>
                        <p><span><%# Eval("Edificio").ToString().Trim() %>, <%# Eval("Piso").ToString().Trim() %></span></p>
                        <p><span><%# "  " + Eval("Telefono").ToString().Trim() %></span></p>
                        <div class="bottomline">
			        </article>                               

                </ItemTemplate>
            </asp:Repeater>
		</div>
	</section>

    <section class="results" id="noResults" runat="server" visible="false">
        <h1>No se encontraron resultados</h1> 
    </section>
	
	<section>
		<div class="container">
			<div class="btns">
				<a class="btn-access" href="http://local.cnv.gov.ar/" target="_blank">
					<img class="imgpasive" src="assets/images/acceso1.png" alt="Sistemas internos"/>
					<img class="imghover"  src="assets/images/acceso1_hover.png" alt="Sistemas internos"/>
				</a>
			    <a class="btn-access" href="http://local.cnv.gov.ar/" target="_blank">
					<img class="imgpasive" src="assets/images/acceso2.png" alt="Contenidos"/>
					<img class="imghover"  src="assets/images/acceso2_hover.png" alt="Contenidos"/>
				</a>
			</div>
		</div>
	</section>
	
	<footer>
		<div class="container">
			<p>Copyright 2017. CNV - Comisión Nacional de Valores - Todos los derechos reservados</p>
			<img src="assets/images/logo_cnv_footer.png" alt="CNV" />
		</div>
	</footer>
    <script>
    var options = {
        url: function (searchTerm) {
            return "Handlers/PersonalHandler.ashx?search=" + searchTerm;
        },
        list: {
            onClickEvent: function () {
                $("#frmSearch").submit();
            }
        }
    };

    $("#search").easyAutocomplete(options);
    </script>
</body>