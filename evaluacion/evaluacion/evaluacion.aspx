<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="evaluacion.aspx.cs" Inherits="evaluacion.evaluacion" %>

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
          <div>
        </div>
          <div>
            <asp:Label ID="lbPromedio" runat="server" Text="Promedio"></asp:Label>
            <asp:TextBox ID="txPromedio" runat="server"></asp:TextBox>
        </div>
        <div>
        </div>
          <div>
              <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </div>
         <asp:Label ID="lbSession" runat="server" Text="Session"></asp:Label>
    </form>
</body>
</html>
