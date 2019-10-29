<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pagina2.aspx.cs" Inherits="sitioExamen2.Pagina2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddCurso" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Agregar" runat="server" OnClick="Agregar_Click" Text="Agregar" />
            <br />
            <asp:Button ID="btReporte" runat="server" OnClick="btReporte_Click" Text="Reporte" />
            <br />
            <asp:Label ID="lbResultados" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
