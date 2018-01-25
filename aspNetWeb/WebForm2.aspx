<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="aspNetWeb.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.js"></script>

     <script type="text/javascript">
         
            
         $(function () {
             $('#insertar_btn').click(function () {
                 guardar();

             });

             $('#btnObtContactos').click(function () {
                 getContactos();

             });
         })
         function guardar() {
             var nom = $("#nombre_text").val();
             var ape = $("#Apellido_text").val();
             var tel = $("#telefono_text").val();
             var ema = $("#email_text").val();
             var pues = $("#puesto_text").val();
             var org_id = $("#DropDownList1").val();

             var usuario = {
                 id:0,
                 nombre: nom,
                 apellido: ape,
                 telefono: tel,
                 email: ema,
                 puesto: pues,
                 organizacion_id: org_id,
                 organizacion:""
             };

             $.ajax(
              {
                  url: "http://localhost:54285/CRUD.asmx/insert",
                  data: JSON.stringify({usuario: usuario}),
                  dataType: "json",
                  type: "POST",
                  contentType: "application/json; charset=utf-8",
                  success: function ( response) {alert(response.d.info)  },
                  error: function (response) {
                      alert("ERROR " + response.status + ' ' + response.statusText)
                  }
              });
         }


         function getContactos() { 
             $.ajax({ 
                 url: "http://localhost:54285/CRUD.asmx/getTable",
                 data: "{}",
                 dataType: "json",
                 type: "POST",
                 contentType: "application/json; charset=utf-8",
                 success: function (response) { 
                     var contactos =  response.d
                                        

                     $('#tablaContactos').empty();
                     $('#tablaContactos').append('<tr><td><b>Nombre</b></td><td><b>Apellido</b></td><td><b>Telefono</b></td><td><b>EMail</b></td><td><b>puesto</b></td><td><b>organizacion_id</b></td></tr>');
            
                     for (var i = 0; i < contactos.length; i++) { 
                         $('#tablaContactos').append('<tr>' + 
                                               '<td>' + contactos[i].nombre + '</td>' +
                                               '<td>' + contactos[i].apellido + '</td>' +
                                               '<td>' + contactos[i].telefono + '</td>' + 
                                               '<td>' + contactos[i].email + '</td>' + 
                                               '<td>' + contactos[i].puesto + '</td>' +
                                                '<td>' + contactos[i].organizacion_id + '</td>' +
                                             '</tr>'); 
                     }
                 }, 
                 error: function (result) { 
                     alert('ERROR ' + result.status + ' ' + result.statusText); 
                 } 
             }); 
         }


       $(function(){$('#delete_btn').click(function(){eliminar();});})

       function eliminar() {
           var id = $("#borrar_text").val();


           $.ajax({
               url: "http://localhost:54285/CRUD.asmx/delete",
               data: JSON.stringify({ id }),
               dataType: "json",
               type: "POST",
               //async: false,
               contentType: "application/json; charset=utf-8",
               success: function (response) { alert(response.d.info) },
               error: function (response) {
                   alert("ERROR " + response.status + ' ' + response.statusText)
               }
           });
       }

   </script>


    <style type="text/css">
        #nombre_text {
            margin-left: 56px;
        }
        #Apellido_text {
            margin-left: 56px;
        }
        #telefono_text {
            margin-left: 55px;
        }
        #email_text {
            margin-left: 76px;
        }
        #puesto_text {
            margin-left: 67px;
        }
        #delete_btn {
            margin-left: 212px;
        }
        #borrar_text {
            margin-left: 7px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
      <div>       
        </div>
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Volver" Width="63px" />
        </p>
        <p>
            Nombre <input type="text" id="nombre_text" />
        </p>
        <p>
            Apellido <input type="text" id="Apellido_text" />
        </p>
        <p>
            Telefono <input type="text" id="telefono_text" />
        </p>
        <p>
            Email <input type="email" id="email_text" />
        </p>
        <p>
            Puesto <input type="text" id="puesto_text" />
        </p>
        <p>
            Organizacion_id 
            <asp:DropDownList ID="DropDownList1" runat="server" style="margin-left: 10px">
            </asp:DropDownList>
        </p>
        <p>
          <input type="button" id="insertar_btn" value="Insertar" style="margin-left:209px" />
          <input type="button" id="btnObtContactos" value="Obtener Contactos" /> <br/><br/> 
          <input type="button" id="delete_btn" value="Borrar" />&nbsp;&nbsp; &nbsp;
         ID: <input type="text" id="borrar_text" />
        </p>
    </form>
          <table id='tablaContactos' border="1"></table>  
        </body>
</html>
