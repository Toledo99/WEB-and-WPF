<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pagina1.aspx.cs" Inherits="sitioExamen2.Pagina1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
&nbsp;
            <asp:TextBox ID="txNombre" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Correo:"></asp:Label>
&nbsp;
            <asp:TextBox ID="txCorreo" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btRegistrar" runat="server" OnClick="Button1_Click" Text="Siguiente" />
            <br />
            <br />
            <asp:Label ID="lbResultados" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
