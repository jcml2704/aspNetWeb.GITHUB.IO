<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="aspNetWeb.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.js"></script>

     <script type="text/javascript">
         $(document).ready(function() {
             function guardar(){
                 var nombre = $("#nombre_text").text();
                 var apellido = $("#apellido_text").text();
                 var telefono = $("#telefono_text").text();
                 var email = $("#email_text").text();
                 var puesto = $("#puesto_text").text();
                 var organizacion_id = $("#organizacion_id_text").text();

                 var user = "{'nombre':'" + nombre + "','apellido':'" + apellido + "','telefono':'" + telefono + "','email':'" + email + "','puesto':'" + puesto + "','organizacion_id':'" + organizacion_id + "'}";

                 $.ajax(
                  {
                       url: "CRUD.asmx.cs/CRUD",
                       data: user,
                       dataType: "json",
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       success: function(msg) { alert(msg.d); },
                       error: function(result) {
                           alert("ERROR " + result.status + ' ' + result.statusText);
                       }
                    });

             }

             $('#insertar_btn').click(function () {
                 guardar();
                
             })
         });

    </script>

</head>
<body>
    <form id="form1" runat="server">
      <div>        
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        </div>
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Volver" Width="63px" />
        </p>
        <p>
            Nombre<asp:TextBox ID="nombre_text" runat="server" style="margin-left: 46px"></asp:TextBox>
        </p>
        <p>
            Apellido<asp:TextBox ID="Apellido_text" runat="server" style="margin-left: 46px"></asp:TextBox>
        </p>
        <p>
            Telefono<asp:TextBox ID="telefono_text" runat="server" style="margin-left: 46px"></asp:TextBox>
        </p>
        <p>
            Email<asp:TextBox ID="email_text" runat="server" style="margin-left: 68px"></asp:TextBox>
        </p>
        <p>
            Puesto<asp:TextBox ID="puesto_text" runat="server" style="margin-left: 61px"></asp:TextBox>
        </p>
        <p>
            Organizacion_id<asp:TextBox ID="organizacion_id_text" runat="server" style="margin-left: 5px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="insertar_btn" runat="server" style="margin-left: 189px" Text="insertar" />
        </p>
    </form>
</body>
</html>
