<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="usoControles.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 77px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="lbUso">
            Uso Controles<br />
            <br />
            Colores:<asp:DropDownList ID="ddColores" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddColores_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lbColores" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="lbContenido" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="lbIndice" runat="server" Text="Label"></asp:Label>
            <br />
            Sabores:<br />
            <asp:RadioButtonList ID="rbSabores" runat="server" AutoPostBack="True">
                <asp:ListItem>Vainilla</asp:ListItem>
                <asp:ListItem>Fresa</asp:ListItem>
                <asp:ListItem>Chocolate</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Label ID="lbCafe" runat="server" Text="cafe"></asp:Label>
            :<br />
            <asp:CheckBoxList ID="cbCafe" runat="server" AutoPostBack="True">
            </asp:CheckBoxList>
            indice:<asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
            <br />
            <br />
            contenido:<asp:ListBox ID="ListBox2" runat="server"></asp:ListBox>
            <br />
        </div>
        <asp:Label ID="lbSession" runat="server" Text="Label"></asp:Label>
        <br />
    </form>
</body>
</html>
