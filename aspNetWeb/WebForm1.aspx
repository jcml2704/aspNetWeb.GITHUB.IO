<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="aspNetWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Formulario</title>
    <style>
        body{background-color:#b6c0f7}
        #consultaH3{text-align:center}
        #boton_crear {
            width: 49px;
        }
        #nombre{margin-left:60px}
        #puesto{margin-left:70px}
        #organizacion{margin-left:30px}
        #boton_crear{margin-left:80px}
        .Cformulario{border-style: solid; border-width: 2px;}
    </style>
</head>
<body>
    <h3 id="consultaH3">MySQL</h3>
    <form id:"formulario class="Cformulario">
        <h3>Crear usuario</h3>
    Nombre: <input type:"text" id="nombre"/> <br />  <br /> 
    Puesto: <input type:"text" id="puesto" /> <br />  <br /> 
    Organización: <input type:"text" id="organizacion" /> <br />  <br />
    <button type:"button" id="boton_crear">Crear</button>
    </form>
</body>
</html>
