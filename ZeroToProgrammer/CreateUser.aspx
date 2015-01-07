<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="ZeroToProgrammer.CreateUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmCreateUser" runat="server">
        <h1>Create User</h1>
        <table>
            <tr>
                <td colspan="2"><asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:label ID="lblUserName" runat="server" text="User Name*:"></asp:label></td>
                <td><asp:TextBox ID="txtUserName" runat="server" Width="120px" MaxLength="15"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:label ID="lblPassword" runat="server" text="Password*:"></asp:label></td>
                <td><asp:TextBox ID="txtPassword" runat="server" Width="120px" TextMode="Password" MaxLength="15"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:label ID="lblConfirmPassword" runat="server" text="Confirm Password*:"></asp:label></td>
                <td><asp:TextBox ID="txtConfirmPassword" runat="server" Width="120px" TextMode="Password" MaxLength="15"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:label ID="lblEmail" runat="server" text="Email*:"></asp:label></td>
                <td><asp:TextBox ID="txtEmail" runat="server" Width="150px" MaxLength="28"></asp:TextBox></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><asp:label ID="lblFirstName" runat="server" text="First Name:"></asp:label></td>
                <td><asp:TextBox ID="txtFirstName" runat="server" Width="120px" MaxLength="15"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:label ID="lblLastName" runat="server" text="Last Name:"></asp:label></td>
                <td><asp:TextBox ID="txtLastName" runat="server" Width="120px" MaxLength="15"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:label ID="lblAge" runat="server" text="Age:"></asp:label></td>
                <td><asp:TextBox ID="txtAge" runat="server" Width="30px" MaxLength="3"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right"><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"/></td>
            </tr>
        </table>

        <p style="font-size: 12px;"><asp:label ID="lblRequired" runat="server" text="Fields marked with * are required"></asp:label></p>
        <p><asp:Label ID="lblSuccess" runat="server" Text="Login Created Successfully" Visible="False" ForeColor="#009933"></asp:Label></p>

    </form>
</body>
</html>
