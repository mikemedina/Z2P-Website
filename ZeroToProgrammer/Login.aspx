<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ZeroToProgrammer.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmLogin" runat="server">
        <h1>Login</h1>
        <table>
            <tr>
                <td colspan="2"><asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:label ID="lblUserName" runat="server" text="User Name:"></asp:label></td>
                <td><asp:TextBox ID="txtUserName" runat="server" Width="120px" MaxLength="15"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:label ID="lblPassword" runat="server" text="Password:"></asp:label></td>
                <td><asp:TextBox ID="txtPassword" runat="server" Width="120px" TextMode="Password" MaxLength="15"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right"><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/></td>
            </tr>
        </table>

        <p><asp:Label ID="lblSuccess" runat="server" Text="Logged in Successfully" Visible="False" ForeColor="#009933"></asp:Label></p>
        <p><asp:Label ID="lblWelcome" runat="server" Text="" Visible="False" ForeColor="#009933"></asp:Label></p>

    </form>
</body>
</html>
