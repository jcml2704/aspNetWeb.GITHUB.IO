<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="aspNetWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <p>
            Nombre:
            <asp:TextBox ID="nombre_text" runat="server" style="margin-left: 58px"></asp:TextBox>
        </p>
        <p>
            Puesto:<asp:TextBox ID="puesto_text" runat="server" style="margin-left: 71px"></asp:TextBox>
        </p>
        <p>
            Organización:<asp:TextBox ID="organizacion_text" runat="server" style="margin-left: 33px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="update_btn" runat="server" OnClick="update_btn_Click" style="margin-left: 178px" Text="Update" />
        </p>
    </form>
</body>
</html>
